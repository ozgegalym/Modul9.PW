using Modul9.PW;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Создание объектов устройств
        var flashDrive = new Flash("FlashDrive", "ABC123", 3.0, 64.0);
        var dvdDisk = new DVD("DVDDisk", "XYZ789", 8.0, "single-sided");
        var removableHDD = new HDD("RemovableHDD", "HDD456", 2.0, 2, 500.0);

        // Добавление устройств в список
        var devices = new List<Storage> { flashDrive, dvdDisk, removableHDD };

        // Создание объекта приложения резервной копии
        var backupApp = new BackupApp(devices);

        // Расчет общего объема памяти
        var totalMemory = backupApp.CalculateTotalMemory();
        Console.WriteLine($"Total Memory: {totalMemory} GB");

        // Копирование данных на устройства
        var dataSize = 565.0; // размер данных в Гб
        var copyTime = backupApp.CopyDataToDevices(dataSize);
        Console.WriteLine($"Time to copy data to devices: {copyTime} hours");

        // Расчет необходимого количества устройств для переноса данных
        var requiredDevices = backupApp.CalculateRequiredDevices(dataSize);
        Console.WriteLine($"Required Devices: {requiredDevices}");

        Console.ReadKey();
    }
}
