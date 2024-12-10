﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateTask();
        }

        void AddMessage(string message)
        {
            int CurrentThreadId = Thread.CurrentThread.ManagedThreadId;
            this.Dispatcher.Invoke(() =>
            {
                Messages.Content +=
                    $"Mensaje: {message}, " +
                    $"Hilo actual: {CurrentThreadId}\n";
            });
        }

        void CreateTask()
        {
            Task T;
            // ¿Qué es un delegado? Apuntador a funciones.
            // Por ejemplo: Action y Func
            Action Code = new Action(ShowMessage);
            T = new Task(Code);

            Task T2 = new Task(delegate
            {
                MessageBox.Show("Ejecutando una tarea en un método anónimo.");
            });

            Task T3A = new Task(ShowMessage);
            Task T3 = new Task(() => ShowMessage());

            // Expresión Lambda:
            // (parámetros de entrada) => Expresión
            // El operador lambda (=>) se lee como "va hacia"
            Task T4 = new Task(() => MessageBox.Show("Ejecutando la tarea 4"));

            Task T5 = new Task(() =>
            {
                DateTime CurrentDate = DateTime.Today;
                DateTime StartDate = CurrentDate.AddDays(30);
                MessageBox.Show($"Tarea 5. Fecha calculada: {StartDate}");
            });

            Task T6 = new Task((message) =>
            {
                MessageBox.Show(message.ToString(), "Expresión lambda con parámetros.");
            });

            Task T7 = new Task(() => AddMessage("Ejecutando la tarea."));
            T7.Start();

            AddMessage("En el hilo principal");
        }

        void ShowMessage()
        {
            MessageBox.Show("Ejecutando el método ShowMessage");
        }
    }