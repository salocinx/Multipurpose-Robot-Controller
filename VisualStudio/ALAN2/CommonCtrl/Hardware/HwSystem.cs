
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Windows;
using System.Windows.Input;
#endregion

namespace CommonCtrl {

    [Serializable]
    public class HwSystem {

        #region Fields
        private string operatingSystem;
        private List<HwCpu> cpus = new List<HwCpu>();
        private List<HwGpu> gpus = new List<HwGpu>();
        private List<HwDisk> disks = new List<HwDisk>();

        [NonSerialized]
        private Dictionary<string, string> cpusx = new Dictionary<string, string>();
        [NonSerialized]
        private Dictionary<string, string> gpusx = new Dictionary<string, string>();
        #endregion

        #region Lifecycle
        public HwSystem() {

            /* lists all possible device information */
            /*this.printDeviceInformation("Win32_Processor");
            this.printDeviceInformation("Win32_LogicalDisk");
            this.printDeviceInformation("Win32_VideoController");*/

            // gather system information from operating system
            this.operatingSystem = Environment.OSVersion.ToString();
            this.getCpuDeviceInformation();
            this.getGpuDeviceInformation();
            this.getDiskDeviceInformation();
            
        }

        private void getCpuDeviceInformation() {
            try {
                ManagementClass mgmtClass = new ManagementClass("Win32_Processor");
                ManagementObjectCollection mgmtObjCol = mgmtClass.GetInstances();
                PropertyDataCollection properties = mgmtClass.Properties;
                foreach(ManagementObject obj in mgmtObjCol) {
                    HwCpu cpu = new HwCpu();
                    cpu.Description = obj.Properties["Name"].Value.ToString(); 
                    cpu.ProcessorCount = int.Parse(obj.Properties["NumberOfLogicalProcessors"].Value.ToString());
                    cpu.Architecture = int.Parse(obj.Properties["AddressWidth"].Value.ToString());
                    cpu.MaxClockSpeed = int.Parse(obj.Properties["MaxClockSpeed"].Value.ToString());
                    cpu.CurrentClockSpeed = int.Parse(obj.Properties["CurrentClockSpeed"].Value.ToString());
                    cpu.DataWidth = int.Parse(obj.Properties["DataWidth"].Value.ToString());
                    cpu.AddressWidth = int.Parse(obj.Properties["AddressWidth"].Value.ToString());
                    cpus.Add(cpu);
                }
            } catch {
                // win-32 class that is not defined on this system
            }
        }

        private void getGpuDeviceInformation() {
            try {
                ManagementClass mgmtClass = new ManagementClass("Win32_VideoController");
                ManagementObjectCollection mgmtObjCol = mgmtClass.GetInstances();
                PropertyDataCollection properties = mgmtClass.Properties;
                foreach(ManagementObject obj in mgmtObjCol) {
                    HwGpu gpu = new HwGpu();
                    gpu.Description = obj.Properties["Description"].Value.ToString();
                    gpu.Type = obj.Properties["AdapterDACType"].Value.ToString();
                    gpu.Ram = ulong.Parse(obj.Properties["AdapterRAM"].Value.ToString());
                    gpu.VideoMode = obj.Properties["VideoModeDescription"].Value.ToString();
                    gpus.Add(gpu);
                }
            } catch {
                // win-32 class that is not defined on this system
            }
        }

        private void getDiskDeviceInformation() {
            try {
                ManagementClass mgmtClass = new ManagementClass("Win32_LogicalDisk");
                ManagementObjectCollection mgmtObjCol = mgmtClass.GetInstances();
                PropertyDataCollection properties = mgmtClass.Properties;
                foreach(ManagementObject obj in mgmtObjCol) {
                    HwDisk disk = new HwDisk();
                    disk.Description = obj.Properties["Description"].Value.ToString()+" ["+obj.Properties["Caption"].Value.ToString()+"]";
                    try {
                        disk.VolumeName = obj.Properties["VolumeName "].Value.ToString();
                    } catch(Exception) {
                        disk.VolumeName = "n/a";
                    }
                    try {
                        disk.VolumeSerialNumber = obj.Properties["VolumeSerialNumber"].Value.ToString();
                    } catch(Exception) {
                        disk.VolumeSerialNumber = "n/a";
                    }
                    try {
                        disk.FileSystem = obj.Properties["FileSystem"].Value.ToString();
                    } catch(Exception) {
                        disk.FileSystem = "n/a";
                    }
                    try {
                        disk.Size = ulong.Parse(obj.Properties["Size"].Value.ToString());
                    } catch(Exception) {
                        disk.Size = 0;
                    }
                    try {
                        disk.FreeSpace = ulong.Parse(obj.Properties["FreeSpace"].Value.ToString());
                    } catch(Exception) {
                        disk.FreeSpace = 0;
                    }
                    disks.Add(disk);
                }
            } catch {
                // win-32 class that is not defined on this system
            }
        }

        private void printDeviceInformation(string win32class) {
            try {
                
                ManagementClass mgmtClass = new ManagementClass(win32class);
                ManagementObjectCollection mgmtObjCol = mgmtClass.GetInstances();
                PropertyDataCollection properties = mgmtClass.Properties;
                Console.WriteLine("************************************************");
                Console.WriteLine(win32class+": Devices: "+mgmtObjCol.Count+" Props: "+properties.Count);
                Console.WriteLine("************************************************");
                foreach(ManagementObject obj in mgmtObjCol) {
                    Console.WriteLine("================================================");
                    Console.WriteLine("Device: "+obj.Properties["Name"].Value.ToString());
                    Console.WriteLine("================================================");
                    foreach(PropertyData property in properties) {
                        try {
                            Console.WriteLine(property.Name+": "+obj.Properties[property.Name].Value.ToString());
                        } catch(Exception) {
                            // ignore duplicates ...
                        }
                    }
                }
            } catch {
                // win-32 class that is not defined on this system
            }
        }
        #endregion

        #region Properties
        public string OperatingSystem {
            get { return operatingSystem; }
            set { operatingSystem = value; }
        }

        public List<HwCpu> CPUs {
            get { return cpus; }
        }

        public List<HwGpu> GPUs {
            get { return gpus; }
        }

        public List<HwDisk> Disks {
            get { return disks; }
        }
        #endregion

    }

    #region CPU
    [Serializable]
    public class HwCpu {

        private string description;
        private int processorCount;
        private int architecture;
        private int maxClockSpeed;
        private int currentClockSpeed;
        private int dataWidth;
        private int addressWidth;

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public int ProcessorCount {
            get { return processorCount; }
            set { processorCount = value; }
        }

        public int Architecture {
            get { return architecture; }
            set { architecture = value; }
        }

        public int MaxClockSpeed {
            get { return maxClockSpeed; }
            set { maxClockSpeed = value; }
        }

        public int CurrentClockSpeed {
            get { return currentClockSpeed; }
            set { currentClockSpeed = value; }
        }

        public int DataWidth {
            get { return dataWidth; }
            set { dataWidth = value; }
        }

        public int AddressWidth {
            get { return addressWidth; }
            set { addressWidth = value; }
        }

    }
    #endregion

    #region GPU
    [Serializable]
    public class HwGpu {

        private string description;
        private string type;
        private ulong ram;
        private string videoMode;

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public string Type {
            get { return type; }
            set { type = value; }
        }

        public ulong Ram {
            get { return ram; }
            set { ram = value; }
        }

        public string VideoMode {
            get { return videoMode; }
            set { videoMode = value; }
        }

    }
    #endregion

    #region Disks
    [Serializable]
    public class HwDisk {

        private string description;
        private string volumeName;
        private string volumeSerialNumber;
        private string fileSystem;
        private ulong size;
        private ulong freeSpace;

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public string VolumeName {
            get { return volumeName; }
            set { volumeName = value; }
        }

        public string VolumeSerialNumber {
            get { return volumeSerialNumber; }
            set { volumeSerialNumber = value; }
        }

        public string FileSystem {
            get { return fileSystem; }
            set { fileSystem = value; }
        }

        public ulong Size {
            get { return size; }
            set { size = value; }
        }

        public ulong FreeSpace {
            get { return freeSpace; }
            set { freeSpace = value; }
        }

    }
    #endregion

}
