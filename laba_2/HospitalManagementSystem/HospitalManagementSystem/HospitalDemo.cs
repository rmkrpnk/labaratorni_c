using System;

public class HospitalDemo
{
    public void Run()
    {
        Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

        Hospital hospital = new Hospital();

        Doctor doctor1 = new Doctor(1, "Воропай Карина", "Сімейний лікар");
        Doctor doctor2 = new Doctor(2, "Возіанова Світлана", "Дерматолог");

        hospital.AddDoctor(doctor1);
        hospital.AddDoctor(doctor2);

        Patient patient1 = new Patient(1, "Гайдученко Богдан", 42);
        Patient patient2 = new Patient(2, "Верзун Влад", 23);
        Patient patient3 = new Patient(3, "Капічніков Єгор", 54);

        hospital.RegisterPatient(patient1);
        hospital.RegisterPatient(patient2);
        hospital.RegisterPatient(patient3);

        HospitalRoom room1 = new HospitalRoom(231, 2);
        HospitalRoom room2 = new HospitalRoom(212, 3);
        HospitalRoom room3 = new HospitalRoom(223, 1);

        hospital.CreateRoom(room1);
        hospital.CreateRoom(room2);
        hospital.CreateRoom(room3);

        hospital.HospitalizePatient(1, 231);
        hospital.HospitalizePatient(2, 212);
        hospital.HospitalizePatient(3, 223);

        MedicalRecord record1 = new MedicalRecord(patient1, doctor1, DateTime.Now.AddDays(0), "Видача справки");
        MedicalRecord record2 = new MedicalRecord(patient2, doctor2, DateTime.Now, "Лікування шкіри");

        hospital.AddMedicalRecord(record1);
        hospital.AddMedicalRecord(record2);

        Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
        var history = hospital.GetPatientHistory(1);
        foreach (var record in history)
        {
            Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
            Console.WriteLine($"  Лікар: {record.Doctor.Name}");
            Console.WriteLine($"  Опис: {record.Description}\n");
        }

        Console.WriteLine(hospital.GetStatistics());
    }
}