using System.Threading;
using System.Net.Sockets;
using System.IO;
using Mancala_Console;
using System.Runtime.CompilerServices;

namespace CIS311_Assignment10_Server
{
    // YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE
    // YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE
    // YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE -- YOUR CODE

    // Chapter 19 - Program 10 - Server

    // This is the server side of a chat program

    // We need to import all of the following for our chat program

    public partial class ServerForm : Form
    {
        TcpListener Server;
        Socket aConnection;
        NetworkStream NetStream;
        BinaryWriter NetWriter;
        BinaryReader NetReader;
        Thread GetDataThread;
        Button[] btnArray;
        MancalaBoard board;

        public ServerForm()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txtMessages.ReadOnly = true;
            cmdStopServer.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
        }


        private void cmdStartServer_Click(object sender, EventArgs e)
        {
            txtMessages.Text = "";
            try
            {
                txtMessages.Text += "Starting Server...\r\n";
                Server = new
                         TcpListener(System.Net.IPAddress.Parse("127.0.0.1"),
                                     int.Parse(txtServerPort.Text));
                Server.Start();

                cmdStopServer.Enabled = true;
                cmdStartServer.Enabled = false;

                txtMessages.Text += "Listening for client connection...\r\n";
                Application.DoEvents();
                aConnection = Server.AcceptSocket();
                txtMessages.Text += "...client connection accepted\r\n";

                NetStream = new NetworkStream(aConnection);

                NetWriter = new BinaryWriter(NetStream);
                NetReader = new BinaryReader(NetStream);

                txtMessages.Text +=
                  "\r\nNetwork stream and reader/writer objects created\r\n";

                txtMessages.Text +=
                   "Preparing thread to watch for data...\r\n";
                GetDataThread = new Thread(GetDataFromClient);
                GetDataThread.Start();

                grpGameControls.Enabled = false;

                if(radP1.Checked == true)
                {
                    takeTurn(2);
                    setTurnMine();
                }
                else
                {
                    setTurnNotMine();
                    takeTurn(1);
                }
            }
            catch (IOException IOEx)
            {
                txtMessages.Text +=
                        "Error in setting up Server -- Closing\r\n";
            }
            catch (SocketException SockEx)
            {
                txtMessages.Text +=
                  "Server already exists -- just restarting listening\r\n";
            }
        }
        private void cmdStopServer_Click(object sender, EventArgs e)
        {
            StopListening();
        }


        void StopListening()
        {
            cmdStartServer.Enabled = true;
            cmdStopServer.Enabled = false;
            txtMessages.Text +=
                 "Attempting to close connection to client...\r\n";
            try
            {
                if (NetWriter != null)
                    NetWriter.Write("~~END~~");
            }

            catch (Exception Ex)
            {
                // We don't need to do anything, but there was a problem
                // communicating with the client
            }

            try
            {
                // Destroy all of the objects that we created
                if (NetWriter != null)
                    NetWriter.Close();
                if (NetReader != null)
                    NetReader.Close();
                if (NetStream != null)
                    NetStream.Close();
                Server.Stop();

                // Dispose might be a better choice here than
                // just setting to null...
                NetWriter = null;
                NetReader = null;
                NetStream = null;
                Server = null;

                try
                {
                    // GetDataThread.Abort();
                    if (GetDataThread != null)
                        GetDataThread = null;
                }
                catch (Exception Ex)
                {
                    // We don't care since we are aborting thread
                }
            }


            catch (Exception Ex)
            {
                // We don't have to do anything since we are leaving anyway
            }

            finally
            {
                txtMessages.Text += "Server has been stopped\r\n";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the user closes the form, make sure we shut things down 
            // properly
            StopListening();
        }

        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE
        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE
        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE
        // MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE -- MY CODE

        /// <summary>
        /// This method will update the board so you can take your turn.
        /// </summary>
        private void setTurnMine()
        {
            int[] myBoard = board.playerHalf;

            foreach (int i in myBoard)
            {
                UpdateButton(btnArray[i], true); // Update button in a thread-safe manner
            }
        }
        /// <summary>
        /// This method is for the safe update of buttons with in threads.
        /// </summary>
        /// <param name="button"></param>   button we are going to update.
        /// <param name="enabled"></param>  state we want to leave it in.
        private void UpdateButton(Button button, bool enabled)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new Action<Button, bool>(UpdateButton), button, enabled);
            }
            else
            {
                button.Enabled = enabled;
            }
        }
        /// <summary>
        /// This method will set the game board up so the user can't interact with the
        /// buttons.
        /// </summary>
        private void setTurnNotMine()
        {
            foreach (Button i in btnArray)
            {
                UpdateButton(i, false);
            }
        }
        /// <summary>
        /// This method will update all the buttons that act as our gameboard.
        /// </summary>
        private void pushToUI()
        {
            int x = 0;
            int[] tempBoard = board.getBoard();

            foreach (Button currentButton in btnArray)
            {
                UpdateButtonText(currentButton, tempBoard[x].ToString());
                x++;
            }
        }
        /// <summary>
        /// This method will handle the updating of buttons within
        /// threads.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="text"></param>
        private void UpdateButtonText(Button button, string text)
        {
            if (button.InvokeRequired)
            {
                button.BeginInvoke(new Action<Button, string>(UpdateButtonText), button, text);
            }
            else
            {
                button.Text = text;
            }
        }
        /// <summary>
        /// This method handles the safe update of textbox's while
        /// in a thread.
        /// </summary>
        /// <param name="message"></param>
        private void UpdateMessagesTextBox(string message)
        {
            if (txtMessages.InvokeRequired)
            {
                txtMessages.Invoke(new Action<string>(UpdateMessagesTextBox), message);
            }
            else
            {
                txtMessages.Text += message;
            }
        }

        private bool firstPassFlag = true;
        /// <summary>
        /// This method will send a message to the server. It will also
        /// handle win/lose/tie logic.
        /// </summary>
        /// <param name="btnClicked"></param>   Is the number sent in
        ///                                     when a user clicks their
        ///                                     bucket / turn.
        private void takeTurn(int btnClicked)
        {
            int lastPebbleDroppedAt = 0;
            if (!firstPassFlag) 
            {
                lastPebbleDroppedAt = board.takeTurn(btnClicked);
                pushToUI();
            }
            
            try
            {
                // Assuming that our network connection to the client is
                // still good, we should be able to send the textbox's
                // contents over the network stream
                if (NetWriter != null)
                    NetWriter.Write(btnClicked.ToString());
                
                if(!firstPassFlag) 
                {
                    txtMessages.Text += "Your Turn:" + board.createString() + Environment.NewLine;

                    if (0 == board.calcMarblesMySide())
                    {//This block is fired only if a winner needs to be found.
                        setTurnNotMine();
                        txtMessages.Text += board.didWin() + "\n";
                    }
                    else if (lastPebbleDroppedAt - 1 == board.myPointFlag)
                    {
                        //This block does nothing :)
                    }
                    else
                    {
                        setTurnNotMine();
                    }
                }               
            }
            // We tried to write to the client and it wasn't there
            catch (SocketException SocketEx)
            {
                txtMessages.Text += "Error writing to client\r\n";
            }

            catch (Exception Ex)
            {
                // Some other exception occurred, don't worry about it
                // at this point.
            }
            firstPassFlag = false;
        }
        /// <summary>
        /// This method will listen for a message to come back from the client.
        /// It will handle turn control along with board updating when needed.
        /// It also makes sure the users still have the ability to move a marble.
        /// If they don't it will display the win/loss/tie message.
        /// </summary>
        void GetDataFromClient()
        {
            /*
            // This is the routine that we spin off into its own thread to 
            // listen for and retrieve network traffic coming to the server
            // from the client.

            // This is a string that we use to pull the data off of the
            // network stream*/
            string TheData = "";
            string textToWriteSomewhere = "";
            int endLocation = 0;


            // Here's the main listening loop that will continue until we
            // receive the ~~END~~ message from the client or the connection
            // abruptly stops.
            try
            {
                do
                {
                    TheData = NetReader.ReadString();

                    textToWriteSomewhere = TheData;
                    endLocation = board.theirTurn(int.Parse(textToWriteSomewhere));
                    pushToUI();
                    string message = "Their Turn: " + board.createString() + Environment.NewLine;
                    UpdateMessagesTextBox(message);


                    if (0 == board.calcMarblesNotMySide())
                    {//This block is fired only if a winner needs to be found.
                        setTurnNotMine();
                        txtMessages.Text += board.didWin() + "\n";
                    }
                    else if (endLocation - 1 == board.notMyPointFlag)
                    {
                        //This does nothing :)
                        //Skips changing the turn.
                    }
                    else
                    {
                        setTurnMine();
                    }
                }
                while ((TheData != "~~END~~") && (aConnection.Connected));
                StopListening();
            }

            // Errors can occur if we try to write to the client and it's
            // not there
            catch (IOException IOEx)
            {
                txtMessages.Text += "Closing connection with client...\r\n";
                StopListening();
            }
        }
        /// <summary>
        /// This method will handle some board setup when the form is first loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerForm_Load(object sender, EventArgs e)
        {
            board = new MancalaBoard(1);
            int[] notMyBoard = board.notMyBoard;
            btnArray = new Button[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11 };
            pushToUI();
            btnArray[5].Enabled = false;
            btnArray[11].Enabled = false;
            setTurnNotMine();      
        }
        /// <summary>
        /// All methods after this point handle click events of the buttons.
        /// They will have no action if their text is set to 0.
        /// and will call takeTurn({#assignt to chosen button})
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, EventArgs e)
        {
            if (btn0.Text != "0")
                takeTurn(0);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text != "0")
                takeTurn(1);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text != "0")
                takeTurn(2);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text != "0")
                takeTurn(3);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text != "0")
                takeTurn(4);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text != "0")
                takeTurn(5);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text != "0")
                takeTurn(6);
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn7.Text != "0")
                takeTurn(7);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text != "0")
                takeTurn(8);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            if (btn9.Text != "0")
                takeTurn(9);
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            if (btn10.Text != "0")
                takeTurn(10);
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            if (btn11.Text != "0")
                takeTurn(11);
        }
    }
}


