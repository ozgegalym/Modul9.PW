using System;
using System.Reflection;
using System.Xml.Linq;

abstract class Storage
{
    public string name;
    public string model;

    public Storage(string name, string model)
    {
        this.name = name;
        this.model = model;
    }

    public abstract double GetMemory();

    public abstract double CopyData(double dataSize);

    public abstract double GetFreeSpace();

    public abstract string GetDeviceInfo();
}

class Flash : Storage
{
    private double usbSpeed;
    private double memorySize;

    public Flash(string name, string model, double usbSpeed, double memorySize)
        : base(name, model)
    {
        this.usbSpeed = usbSpeed;
        this.memorySize = memorySize;
    }

    public override double GetMemory()
    {
        return memorySize;
    }

    public override double CopyData(double dataSize)
    {
        return dataSize / usbSpeed;
    }

    public override double GetFreeSpace()
    {
        return memorySize;
    }
    public override string GetDeviceInfo()
    {
        return $"Flash - {name} {model}, USB Speed: {usbSpeed} GB/s, Memory: {memorySize} GB";
    }
}

class DVD : Storage
{
    private double readWriteSpeed;
    private string discType;

    public DVD(string name, string model, double readWriteSpeed, string discType)
        : base(name, model)
    {
        this.readWriteSpeed = readWriteSpeed;
        this.discType = discType;
    }

    public override double GetMemory()
    {
        return discType == "single-sided" ? 4.7 : 9.0;
    }

    public override double CopyData(double dataSize)
    {
        return dataSize / readWriteSpeed;
    }

    public override double GetFreeSpace()
    {
        return GetMemory();
    }
    public override string GetDeviceInfo()
    {
        return $"DVD - {name} {model}, Read/Write Speed: {readWriteSpeed}, Type: {discType}";
    }
}

class HDD : Storage
{
    private double usbSpeed;
    private int partitions;
    private double partitionSize;

    public HDD(string name, string model, double usbSpeed, int partitions, double partitionSize)
        : base(name, model)
    {
        this.usbSpeed = usbSpeed;
        this.partitions = partitions;
        this.partitionSize = partitionSize;
    }

    public override double GetMemory()
    {
        return partitions * partitionSize;
    }

    public override double CopyData(double dataSize)
    {
        return dataSize / usbSpeed;
    }

    public override double GetFreeSpace()
    {
        return partitions * partitionSize;
    }

    public override string GetDeviceInfo()
    {
        return $"HDD - {name} {model}, USB Speed: {usbSpeed} GB/s, Partitions: {partitions}, Partition Size: {partitionSize} GB";
    }
}
