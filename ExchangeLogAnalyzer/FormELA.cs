using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeLogAnalyzer {
    public partial class FormELA : Form {
        ELAKernel kernel;

        public FormELA() {
            InitializeComponent();
            kernel = new ELAKernel();
            kernel.OnDataLoadBegin += Kernel_OnDataLoad;
            kernel.OnDataLoadEnd += Kernel_OnDataLoad;
            kernel.OnDataLoadProgress += Kernel_OnDataLoadProgress;
            kernel.OnKernelModeChanged += Kernel_OnKernelModeChanged;
            kernel.Initialize(Properties.Settings.Default.SourcePaths.Split('|'));
            initializeGUI();
            kernel.LoadData();
        }

        private void initializeGUI() {
            initializeHeaders();
        }

        #region Kernel events
        private void Kernel_OnKernelModeChanged(object sender, OnKernelModeChangedEventArgs e) {
            //throw new NotImplementedException();
        }

        private void Kernel_OnDataLoad(object sender, OnDataLoadEventArgs e) {
            switch (e.Phase) {
                case LoadPhase.Begin:
                    //ssMain.Items.Add(new ToolStripProgressBar("Test"));
                    //(ssMain.Items["Test"] as ToolStripProgressBar).Value = 70;
                    //(ssMain.Items["Test"] as ToolStripProgressBar).Maximum = 100;
                    break;
                case LoadPhase.End:
                    //ssMain.Items["Test"].Dispose();
                    break;
                default:
                    break;
            }
        }

        private void Kernel_OnDataLoadProgress(object sender, OnDataLoadProgressEventArgs e) {
            //throw new NotImplementedException();
        }
        #endregion

        #region Utilities
        private void initializeHeaders() {
            setHeaders(lvData, "Timestamp,SessionId,LocalEndpoint,RemoteEndpoint,EnteredOrgFromIP,MessageId,P1FromAddress,P2FromAddresses,Recipient,NumRecipients,Agent,Event,Action,SmtpResponse,Reason,ReasonData,Diagnostics".Split(','));
            //autoResizeColumns(lvData, ColumnHeaderAutoResizeStyle.HeaderSize);
            manageControl(lvData, BindingFlags.InvokeMethod, null, "AutoResizeColumns", new object[] { ColumnHeaderAutoResizeStyle.HeaderSize });
            ////Set1(this, "Text", "Hello");
            //SetHeaders(lvStatActions, "Action,Count,Percent,".Split(','));
            //SetHeaders(lvStatReason, "Reason,Count,Percent,".Split(','));
            //SetHeaders(lvStatBLP, "BLP,Count,Percent,".Split(','));
            //SetHeaders(lvStatSCL, "SCL,Count,Percent,".Split(','));
            //SetHeaders(lvStatSIPC, "SourceIP,Count,Percent,".Split(','));
            //SetHeaders(lvStatSpammers, "SourceIP,Country,City,ISP,Count,Percent,".Split(','));

        }

        private void setHeaders(ListView lv, string[] headers) {
            if (lv.InvokeRequired) {
                lv.Invoke((MethodInvoker)delegate {
                    setHeaders(lv, headers);
                });
            } else {
                foreach (string header in headers) {
                    ColumnHeader ch = new ColumnHeader() { Text = header.Trim() };
                    if ((header == "Count") || (header == "Percent")) ch.TextAlign = HorizontalAlignment.Right;
                    lv.Columns.Add(ch);
                }
            }
        }
        //====================================================================================================================================
        private void autoResizeColumns(ListView lv, ColumnHeaderAutoResizeStyle columnHeaderAutoResizeStyle) {
            if (lv.InvokeRequired) {
                lv.Invoke((MethodInvoker)delegate {
                    autoResizeColumns(lv, columnHeaderAutoResizeStyle);
                });
            } else {
                lv.AutoResizeColumns(columnHeaderAutoResizeStyle);
            }
        }
        //====================================================================================================================================
        private void fillInListView(ListView lv, IEnumerable<ELAAgentLogRecord> values) {
            if (lv.InvokeRequired) {
                lv.Invoke((MethodInvoker)delegate {
                    fillInListView(lv, values);
                });
            } else {
                lv.Items.Clear();
                foreach (ELAAgentLogRecord item in values) {
                    ListViewItem lvi = new ListViewItem(item.ToString().Split('|'));
                    switch (item.Action) {
                        case "AcceptMessage":
                            lvi.BackColor = Color.FromArgb(199, 254, 194);
                            break;
                        case "QuarantineMessage":
                            lvi.BackColor = Color.FromArgb(254, 223, 167);
                            break;
                        case "RejectCommand":
                        case "RejectMessage":
                            lvi.BackColor = Color.FromArgb(255, 172, 166);
                            break;
                        default:
                            break;
                    }
                    lv.Items.Add(lvi);
                }
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        #endregion
        private void manageControl(Control control, BindingFlags bindingFlags, Binder binder, string propertyName, object[] propertyValues) {
            if (control.InvokeRequired) {
                control.Invoke((MethodInvoker)delegate { manageControl(control, bindingFlags, binder, propertyName, propertyValues); });
            } else {
                control.GetType().InvokeMember(
                    propertyName,
                    bindingFlags,
                    binder,
                    control,
                    propertyValues
                );
            }
        }

        #region Test
        //public delegate void Set1Delegate(Control control, string propName, object propValue);

        public void Set1(Control control, string propName, object propValue) {
            if (control.InvokeRequired) {
                control.Invoke((MethodInvoker)delegate { Set1(control, propName, propValue); });
            } else {
                control.GetType().InvokeMember(
                    propName,
                    System.Reflection.BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] {
                        propValue
                    }
                );
            }
        }
        #endregion
    }
}
