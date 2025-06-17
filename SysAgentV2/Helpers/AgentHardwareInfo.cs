using Hardware.Info;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models.Infos;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Management;
using System.ServiceProcess;

namespace SysAgentV2.Helpers
{
    [ExcludeFromCodeCoverage]
    public class AgentHardwareInfo : IAgentHardwareInfo
    {
        private readonly IHardwareInfo _hardwareInfo;
        public AgentHardwareInfo(IHardwareInfo hardwareInfo)
        {
            _hardwareInfo = hardwareInfo;
        }
        public int GetQtyCore()
        {
            return Environment.ProcessorCount;
        }
        public uint GetCpuFrequency()
        {
            try
            {
                _hardwareInfo.RefreshCPUList();

                var cpu = _hardwareInfo.CpuList.FirstOrDefault();
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

        public Cpu GetInfoCpu()
        {
            return new Cpu()
            {
                NameProcessor = GetProcessorName(),
                Core = GetQtyCore(),
                Frequency = GetCpuFrequency(),
                UsagePercent = GetCpuUsage(),
            };
        }

        public List<Disk> GetInfoDisk()
        {
            List<Disk> list = new List<Disk>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    long totalSpace = drive.TotalSize / (1024 * 1024 * 1024);
                    long freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                    long usedSpace = totalSpace - freeSpace;

                    list.Add(new Disk()
                    {
                        Name = drive.Name,
                        Info = new DictionaryInfoDisk()
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

        public Models.Infos.Memory GetInfoMemory()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            Models.Infos.Memory? memory = new Models.Infos.Memory();
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

        public List<Models.Infos.Process> GetListProcess()
        {
            var listProcess = new List<Models.Infos.Process>();

            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();

            foreach (System.Diagnostics.Process process in processes)
            {
                try
                {
                    long memoryMB = process.WorkingSet64 / (1024 * 1024);

                    if (memoryMB > 0)
                        listProcess.Add(new Models.Infos.Process
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

        public Models.Infos.Process GetProcessByPid(int pid)
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();

            try
            {
                foreach (System.Diagnostics.Process process in processes)
                {
                    if (process.Id == pid)
                    {
                        long memoryMB = process.WorkingSet64 / (1024 * 1024);

                        var processModel = new Models.Infos.Process
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
        public List<Service> GetListServices()
        {
            var services = ServiceController.GetServices();
            List<Service> listServices = new List<Service>();
            foreach (var service in services)
            {
                listServices.Add(new Models.Infos.Service
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

        public (bool, Models.Infos.Process) KillProcessByPid(int pid)
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
            try
            {
                foreach (System.Diagnostics.Process process in processes)
                {
                    if (process.Id == pid)
                    {
                        long memoryMB = process.WorkingSet64 / (1024 * 1024);

                        var processModel = new Models.Infos.Process
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

        public List<EventView> GetEventViewList(string logName, string date, string lastTime)
        {
            List<EventView> listEventView = new List<EventView>();
            EventLog eventLog = new EventLog(logName);
            int total = eventLog.Entries.Count;

            int maxResults = lastTime == "*" ? int.MaxValue : Convert.ToInt32(lastTime);

            for (int i = total - 1; i >= 0 && listEventView.Count < maxResults; i--) 
            {
                var entry = eventLog.Entries[i];
                if (entry.TimeGenerated.ToString("yyyy-MM-dd") == date)
                {
                    listEventView.Add(new EventView
                    {
                        EntryType = entry.EntryType.ToString(),
                        Source = entry.Source,
                        Message = entry.Message,
                        TimeGenerated = entry.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss"),
                    });
                }
            }

            return listEventView;
        }

        public string ExecuteScriptCmd(string script)
        {
            try
            {
                string output = "";
                string error = "";
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {script}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi))
                {
                    output = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    Console.WriteLine("Saída:");
                    Console.WriteLine(output);

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        return error;
                    }
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
