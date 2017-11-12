using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeLogAnalyzer {
    public partial class FormELA : Form {
        ELAKernel kernel;

        public FormELA() {
            InitializeComponent();
            kernel = new ELAKernel();
            kernel.OnDataLoad += Kernel_OnDataLoad;
            kernel.OnKernelModeChanged += Kernel_OnKernelModeChanged;
            kernel.Initialize();
            initializeGUI();
        }

        private void initializeGUI() {
            initializeHeaders();
        }

        #region Kernel events
        private void Kernel_OnKernelModeChanged(object sender, OnKernelModeChangedEventArgs e) {
            throw new NotImplementedException();
        }

        private void Kernel_OnDataLoad(object sender, OnDataLoadEventArgs e) {
            if (e.IsPrimaryLoading) {

            } else {

            }
        }
        #endregion

        #region Utilities
        private void initializeHeaders() {
            setHeaders(lvData, "Timestamp,SessionId,LocalEndpoint,RemoteEndpoint,EnteredOrgFromIP,MessageId,P1FromAddress,P2FromAddresses,Recipient,NumRecipients,Agent,Event,Action,SmtpResponse,Reason,ReasonData,Diagnostics".Split(','));
            autoResizeColumns(lvData, ColumnHeaderAutoResizeStyle.HeaderSize);
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
                    setHeadersHandler(lv, headers);
                });
            } else {
                setHeadersHandler(lv, headers);
            }
        }

        private static void setHeadersHandler(ListView lv, string[] headers) {
            foreach (string header in headers) {
                ColumnHeader ch = new ColumnHeader() { Text = header.Trim() };
                if ((header == "Count") || (header == "Percent")) ch.TextAlign = HorizontalAlignment.Right;
                lv.Columns.Add(ch);
            }
        }
        //====================================================================================================================================
        private void autoResizeColumns(ListView lv, ColumnHeaderAutoResizeStyle columnHeaderAutoResizeStyle) {
            if (lv.InvokeRequired) {
                lv.Invoke((MethodInvoker)delegate {
                    autoResizeColumnsHandler(lv, columnHeaderAutoResizeStyle);
                });
            } else {
                autoResizeColumnsHandler(lv, columnHeaderAutoResizeStyle);
            }
        }

        private static void autoResizeColumnsHandler(ListView lv, ColumnHeaderAutoResizeStyle columnHeaderAutoResizeStyle) {
            lv.AutoResizeColumns(columnHeaderAutoResizeStyle);
        }

        #endregion

    }
}
