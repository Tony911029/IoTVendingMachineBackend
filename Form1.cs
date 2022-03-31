using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTVendingMachineBackend
{
    public partial class Form1 : Form
    {
        // all lower case
        string product1 = "chocolatebar";
        string product2 = "popcorn";
        string product3 = "twix";
        string product4 = "gummybear";

        int item1Num;
        int item2Num;
        int item3Num;
        int item4Num;
        
        public Form1()
        {
            InitializeComponent();
        }

        private static DeviceClient deviceClient;
        private void Form1_Load(object sender, EventArgs e)
        {
            int device = 1;  // using device 1 only as an example  (Tony Chan's device is number 1)
            deviceClient = DeviceClient.CreateFromConnectionString(BuildConnectionString(device), TransportType.Mqtt); // connect to the cloud

            name1.Text = product1;
            name2.Text = product2;
            name3.Text = product3;
            name4.Text = product4;

            ConnectToArduino();

            // Initialize the stocks
            // output: "itemName,Num"
            // product1
            Console.WriteLine(product1);
            item1Num = Convert.ToInt32(Console.ReadLine()); // initialize the stock from seller (me)
            string output1 = product1 + ',' + item1Num;
            Console.WriteLine(output1);
            port.Write(output1); // update the stock in IDE
            port.ReadLine(); // skip the line we send
            Console.WriteLine(" ");


            // product2
            Console.WriteLine(product2);
            item2Num = Convert.ToInt32(Console.ReadLine());
            string output2 = product2 + ',' + item2Num;
            Console.WriteLine(output2);
            port.Write(output2);
            port.ReadLine();
            port.Write(product2);
            Console.WriteLine(" ");


            // product3
            Console.WriteLine(product3);
            item3Num = Convert.ToInt32(Console.ReadLine());
            string output3 = product3 + ',' + item3Num;
            Console.WriteLine(output3);
            port.Write(output3);
            port.ReadLine();
            port.Write(product3);
            Console.WriteLine(" ");
            

            // product4
            Console.WriteLine(product4);
            item4Num = Convert.ToInt32(Console.ReadLine());
            string output4 = product4 + ',' + item4Num;
            Console.WriteLine(output4);
            port.Write(output4);
            port.ReadLine();
            port.Write(product4);
            Console.WriteLine(" ");

            string msg = "Simulating device wchs00" + device.ToString() + ".  Ctrl-C to exit.\n";
            Console.WriteLine(msg);


            
            // send the stock to the frontend first
            item = new Product(product1, item1Num);
            AdjustStock();
            Thread.Sleep(500);

            item = new Product(product2, item2Num);
            AdjustStock();
            Thread.Sleep(500);

            item = new Product(product3, item3Num);
            AdjustStock();
            Thread.Sleep(500);

            item = new Product(product4, item4Num);
            AdjustStock();
            


        }


        SerialPort port;
        private void ConnectToArduino()
        {
            try
            {
                port = new SerialPort
                {
                    BaudRate = 9600,
                    PortName = "COM11" // change the port if needed
                };

                port.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered error while reading serial port");
                Console.WriteLine(ex.ToString());
                System.Threading.Thread.Sleep(50000);
            }
        }

        

        private async Task GrabDataFromArduino() // Normal 
        {
            try
            {
                while (true)
                {
                    string dataFromArduino = port.ReadLine(); // blocking call so we have to use a new thread for this method
                    dataFromArduino = dataFromArduino.Replace("\r", ""); // message includes "\r" in Seral buffer
                    // incoming string: just itemName


                    // *Do I really need to notify myslef for out of stock...? while the machine will literally be beside it..?
                    Product normalItem = null;

                    if (dataFromArduino == product1 && (item1Num != 0))
                    {
                        item1Num--; // decrease the num by one after we know a item is sell
                        normalItem = new Product(dataFromArduino, item1Num);
                    }

                    if ((dataFromArduino == product2) && (item2Num != 0))
                    {
                        item2Num--;
                        normalItem = new Product(dataFromArduino, item2Num);
                    }

                    if ((dataFromArduino == product3) && (item3Num != 0))
                    {
                        item3Num--;
                        normalItem = new Product(dataFromArduino, item3Num);
                    }

                    if ((dataFromArduino == product4) && (item4Num != 0))
                    {
                        item4Num--;
                        normalItem = new Product(dataFromArduino, item4Num);
                    }


                    if (normalItem != null)
                    {
                        string jsonData = JsonConvert.SerializeObject(normalItem);
                        Microsoft.Azure.Devices.Client.Message message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(jsonData));


                        // Send the JSON message to Azure 
                        await deviceClient.SendEventAsync(message); // send the data to the cloud 


                        // Console.WriteLine("{0:G} > Sent msg: {1}", DateTime.Now, jsonData.ToString()); // send the data to our console
                        string displayMessage = "{0:G} > Sent msg: {1}" + DateTime.Now + jsonData.ToString();
                        // listBox1.Items.Add(displayMessage);
                        Console.WriteLine(displayMessage);

                        await Task.Delay(5000);  // do not reduce this time interval (interval of each measurement)


                        System.Threading.Thread.Sleep(500);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered error while reading serial port");
                Console.WriteLine(ex.ToString());
                System.Threading.Thread.Sleep(50000);
            }

            
        }
        private static string BuildConnectionString(int device)
        {
            string connectionString = "HostName=HellingaHub.azure-devices.net;DeviceId=wchs00";
            connectionString += device.ToString(); // end with 001 in this case

            switch (device)
            {
                case 1: connectionString += ";SharedAccessKey=Z6Vt7Trr5KBLV9CjPJ38vJlz4UIKKa3r8CUXNm8Ms+4="; break;
                case 2: connectionString += ";SharedAccessKey=lyC8xfEoBrTTZVJ/9zvs111SJosH4fYCMiSzxIV+CPA="; break;
                case 3: connectionString += ";SharedAccessKey=y/86Fww/H5buYweTeHX1Y0vxqdpSB6StopChZQ7bQPw="; break;
                case 4: connectionString += ";SharedAccessKey=ufNV0f/4ZuvdImYRokL+UjZi/hHJMp5TL/V9brIBFX8="; break;
                case 5: connectionString += ";SharedAccessKey=H2Dx6CQc9V+6cHyB1CY8MwkzY14I1HgyaXIfk8onmKQ="; break;
                case 6: connectionString += ";SharedAccessKey=7bDraa8uywFjRhdysTZ/7TBeyYPy9ln/QwtLBYGIx5w="; break;
            }
            return connectionString;
        }


        Product item;
        int num;
        private async void AdjustStock()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(item);

                Microsoft.Azure.Devices.Client.Message message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(jsonData));

                await deviceClient.SendEventAsync(message); // send the data to the cloud 

                string displayMessage = "{0:G} > Sent msg: {1}" + DateTime.Now + jsonData.ToString();
                Console.WriteLine(displayMessage);
                port.ReadLine(); // skip the line we just send to Arduino

                await Task.Delay(5000);  // do not reduce this time interval (interval of each measurement)
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered error while reading serial port");
                Console.WriteLine(ex.ToString());
                System.Threading.Thread.Sleep(50000);
            }

        }

        // adjust the number 
        private void button1_Click(object sender, EventArgs e)
        {
            num = Convert.ToInt32(item1.Text);
            item = new Product(name1.Text.ToLower(), num);
            port.Write(name1.Text + "," + num);  // Output: Chocolate,num: for adjustment in Arduino
            AdjustStock(); // This method will skip the line we just write
        }

        private void button2_Click(object sender, EventArgs e)
        {
            num = Convert.ToInt32(item2.Text);
            item = new Product(name2.Text.ToLower(), num);
            port.Write(name2.Text+","+num);
            AdjustStock();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            num = Convert.ToInt32(item3.Text);
            item = new Product(name3.Text.ToLower(), num);
            port.Write(name3.Text + "," + num);
            AdjustStock();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            num = Convert.ToInt32(item4.Text);
            item = new Product(name4.Text.ToLower(), num);
            port.Write(name4.Text + "," + num);
            AdjustStock();
        }


        // update the stock from arduino
        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            // create a new thread that is used only to grab the data from arduino like some item is sold.
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                // Thread.CurrentThread.Join(); // main thead will never stop until the child thread is finished, which wont't happened in the while loop
                /* run your code here */
                // Console.WriteLine("Grabing data from Arduino...");
                GrabDataFromArduino(); // keep sending the data
            }).Start();

            
        }

    }
}
