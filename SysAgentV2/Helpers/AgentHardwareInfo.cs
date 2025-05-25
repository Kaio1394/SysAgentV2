using Hardware.Info;
using SysAgentV2.Helpers.Interfaces;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;

namespace SysAgentV2.Helpers
{
    public class AgentHardwareInfo : IAgentHardwareInfo
    {
        public int GetQtyCore()
        {
            return Environment.ProcessorCount;
        }
        public uint GetCpuFrequency()
        {
            try
            {
                var hardwareInfo = new HardwareInfo();
                hardwareInfo.RefreshCPUList();

                var cpu = hardwareInfo.CpuList.FirstOrDefault();
                return cpu.MaxClockSpeed;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetProcessorName()
        {
            string cpuName = "Desconhecido";
            try
            {
                using var searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    cpuName = obj["Name"]?.ToString() ?? "Desconhecido";
                    break;
                }
                return cpuName.Trim();
            }
            catch
            {
                return "Desconhecido";
            }
        }

        public float GetCpuUsage()
        {
            try
            {
                using var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                _ = cpuCounter.NextValue();

                System.Threading.Thread.Sleep(1000);

                float cpuUsage = cpuCounter.NextValue();
                return cpuUsage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Models.Cpu GetInfoCpu()
        {
            return new Models.Cpu()
            {
                NameProcessor = GetProcessorName(),
                Core = GetQtyCore(),
                Frequency = GetCpuFrequency(),
                UsagePercent = GetCpuUsage(),
            };
        }

        public List<Models.Disk> GetInfoDisk()
        {
            List<Models.Disk> list = new List<Models.Disk>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    long totalSpace = drive.TotalSize / (1024 * 1024 * 1024);
                    long freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                    long usedSpace = totalSpace - freeSpace;

                    list.Add(new Models.Disk()
                    {
                        Name = drive.Name,
                        Info = new Models.DictioaryInfoDisk()
                        {
                            TotalSpace = totalSpace,
                            UsedSpace = usedSpace,
                            FreeSpace = freeSpace,
                        }
                    });
                }
            }
            return list;
        }

        public Models.Memory GetInfoMemory()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            Models.Memory? memory = new Models.Memory();
            foreach (var obj in searcher.Get())
            {
                double totalVisibleMemory = Convert.ToDouble(obj["TotalVisibleMemorySize"]) / 1024; 
                double freePhysicalMemory = Convert.ToDouble(obj["FreePhysicalMemory"]) / 1024;   
                double usedMemory = totalVisibleMemory - freePhysicalMemory;

                memory.Total = $"{totalVisibleMemory:F2} MB";
                memory.Free = $"{freePhysicalMemory:F2} MB";
                memory.Usage = $"{usedMemory:F2} MB";
            }
            return memory;
        }

        public List<Models.Process> GetListProcess()
        {
            var listProcess = new List<Models.Process>();

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    long memoryMB = process.WorkingSet64 / (1024 * 1024);

                    if (memoryMB > 0)
                        listProcess.Add(new Models.Process
                        {
                            Id = process.Id,
                            Name = process.ProcessName,
                            UsageMemoryAux = memoryMB,
                            UsageMemory = $"{memoryMB} MB"
                        });
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return listProcess.OrderByDescending(x => x.UsageMemoryAux).ToList();
        }

        public Models.Process GetProcessByPid(int pid)
        {
            Process[] processes = Process.GetProcesses();

            try
            {
                foreach (Process process in processes)
                {
                    if (process.Id == pid)
                    {
                        long memoryMB = process.WorkingSet64 / (1024 * 1024);

                        var processModel = new Models.Process
                        {
                            Id = process.Id,
                            Name = process.ProcessName,
                            UsageMemoryAux = memoryMB,
                            UsageMemory = $"{memoryMB} MB"
                        };
                        return processModel;
                    }                 
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            } 
        }
        public List<Models.Service> GetListServices()
        {
            var services = ServiceController.GetServices();
            List<Models.Service> listServices = new List<Models.Service>();
            foreach (var service in services)
            {
                listServices.Add(new Models.Service
                {
                    DisplayName = service.DisplayName,
                     ServiceName = service.ServiceName,
                     Status = service.Status.ToString(),
                });
            }
            return listServices;
        }

        public bool StartServiceByDisplayName(string displayName)
        {
            var services = ServiceController.GetServices();
            foreach (var service in services)
            {
                if (service.DisplayName == displayName)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(60));
                    return true;
                }
            }
            return false;
        }

        public bool StopServiceByDisplayName(string displayName)
        {
            var services = ServiceController.GetServices();
            foreach (var service in services)
            {
                if (service.DisplayName == displayName)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(60));
                    return true;
                }
            }
            return false;
        }

        public bool StopServiceByServiceName(string serviceName)
        {
            var services = ServiceController.GetServices();
            foreach (var service in services)
            {
                if (service.ServiceName == serviceName)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(60));
                    return true;
                }
            }
            return false;
        }

        public (bool, Models.Process) KillProcessByPid(int pid)
        {
            Process[] processes = Process.GetProcesses();
            try
            {
                foreach (Process process in processes)
                {
                    if (process.Id == pid)
                    {
                        long memoryMB = process.WorkingSet64 / (1024 * 1024);

                        var processModel = new Models.Process
                        {
                            Id = process.Id,
                            Name = process.ProcessName,
                            UsageMemoryAux = memoryMB,
                            UsageMemory = $"{memoryMB} MB"
                        };

                        process.Kill();
                        process.WaitForExitAsync();

                        return (true, processModel);
                    }
                }
                return (false, null);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
