using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ticketing_System
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
            using (StreamReader savedata = new StreamReader("H:\\Students_Folder\\Grant Malone\\Coding\\Visual Studio Assets\\Ticketing System\\Ticketing System\\Data Grid Data.txt")) //reads Data.txt file
            {
                string line; //creates string variable "line"
                while ((line = savedata.ReadLine()) != null) //while there is text on the next line of Data.txt execute the following
                {

                    string[] ticketInfo = line.Split('-');
                    Ticket revisedTicket = new Ticket();
                    revisedTicket.priority = int.Parse(ticketInfo[0]);
                    revisedTicket.time = DateTime.Parse(ticketInfo[1]);
                    revisedTicket.workstation = ticketInfo[2];
                    revisedTicket.description = ticketInfo[3];
                    ticketOrder.Add(revisedTicket);

                    if (revisedTicket.priority == 1)
                    {
                        dgridTickets.Rows.Add("High", revisedTicket.time, revisedTicket.workstation, revisedTicket.description);
                    }
                    else if (revisedTicket.priority == 2)
                    {
                        dgridTickets.Rows.Add("Normal", revisedTicket.time, revisedTicket.workstation, revisedTicket.description);
                    }
                    else if (revisedTicket.priority == 3)
                    {
                        dgridTickets.Rows.Add("Low", revisedTicket.time, revisedTicket.workstation, revisedTicket.description);
                    }
                }
            }
        }

        public class Ticket
        {
            public string description; //variable for description box
            public string workstation; //variable for workstation box
            public int priority; //variable for priority box
            public DateTime time = DateTime.Now; //variable for time box
        }

        List<Ticket> ticketOrder = new List<Ticket>(); //creates new list
        
        

        public void userCustomer()
        {
            //if customer log in then resolve button is disabled and invisible
            btnResolve.Visible = false; 
            btnResolve.Enabled = false;
        }
        public void btnSubmit_Click(object sender, EventArgs e)
        {

            
            Ticket newticket = new Ticket(); //creates new instance for each ticket
            



            if (cboxWorkstation.Text == "" || cboxWorkstation.Text == " " || cboxPriority.Text == "" || cboxPriority.Text == " " || txtDescription.Text == "" || txtDescription.Text == " ")
            {
                //if any boxes are empty do nothing
            }
            else
            {
                newticket.description = txtDescription.Text; //puts text box text in ticket instance
                newticket.workstation = cboxWorkstation.Text; // puts workstation in ticket instance
                newticket.time = DateTime.Now; //puts time in ticket instance
                
                //changes priority level to easier sort
                if (cboxPriority.Text == "High")
                {
                    newticket.priority = 1; //changes the priority level to 1
                }
                else if (cboxPriority.Text == "Normal")
                {
                    newticket.priority = 2; //changes the priority level to 2
                }
                else if (cboxPriority.Text == "Low")
                {
                    newticket.priority = 3; //changes the prioirty level to 3
                }
                else
                {
                    //else do nothing
                }


                ticketOrder.Add(newticket); //adds each ticket instance to the list of tickets
                List<Ticket> SortedList = ticketOrder.OrderBy(o => o.priority).ToList(); //sorts list by priority 
                dgridTickets.Rows.Clear(); //clear data grid rows


                foreach (Ticket tick in SortedList) //for each ticket is SortedList execute the following
                {
                    if (tick.priority == 1)
                    {
                        dgridTickets.Rows.Add("High", tick.time, tick.workstation, tick.description); //Change priority level 1 to "High" text
                    }
                    else if (tick.priority == 2)
                    {
                        dgridTickets.Rows.Add("Normal", tick.time, tick.workstation, tick.description); //Change priority level 2 to "Normal" text
                    }
                    else if (tick.priority == 3)
                    {
                        dgridTickets.Rows.Add("Low", tick.time, tick.workstation, tick.description); //Change priority level 3 to "Low" text
                    }
                }

                using (StreamWriter newdata = new StreamWriter("H:\\Students_Folder\\Grant Malone\\Visual Studio Assets\\Ticketing System\\Ticketing System\\Data Grid Data.txt")) //writes to Data Grid Data.txt
                {
                    foreach (Ticket line in ticketOrder) //for each line in listbox execute
                    {
                        newdata.WriteLine(line.priority + " - " + line.time + " - " + line.workstation + " - " + line.description); //writes each line from list box in Data Grid Data.txt
                    }

                }

                cboxPriority.Text = " "; //Clear combo box
                cboxWorkstation.Text = " "; //clear combo box
                txtDescription.Text = ""; //clears txt box
            }
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {


            if (dgridTickets.Rows.Count == 0)
            {
                //if no rows do nothing
            }
            else
            {
                ticketOrder.RemoveAt(dgridTickets.CurrentRow.Index); //remove the ticket from "ticketOrder" list
                dgridTickets.Rows.Remove(dgridTickets.CurrentRow); //remove the row from data grid
                using (StreamWriter newdata = new StreamWriter("H:\\Students_Folder\\Grant Malone\\Visual Studio Assets\\Ticketing System\\Ticketing System\\Data Grid Data.txt")) //writes to Data.txt
                {
                    foreach (object line in dgridTickets.Rows) //for each line in list box execute
                    {
                        newdata.WriteLine(line); //writes each line from list box in Data.txt
                    }
                }
            }
        }
        public void dgridTickets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgridTickets.CurrentRow.Index >= 0)
            {
                Ticket selectedTicket = ticketOrder[dgridTickets.CurrentRow.Index]; // selected ticket variable equals the row that is double clicked
                string description = selectedTicket.description; //description variable equals the description column of the selected row
                MessageBox.Show(description); //show description in message box
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //close application
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<Ticket> ticketSearch =
                from desc in ticketOrder
                where desc.description.ToLower().Contains(txtSearch.Text.ToLower())
                select desc;

            dgridTickets.Rows.Clear(); //clear data grid
             
            foreach (Ticket ticket in ticketSearch)
            {
                dgridTickets.Rows.Add(ticket.priority, ticket.time, ticket.workstation, ticket.description); //
            }
        }
    }
}