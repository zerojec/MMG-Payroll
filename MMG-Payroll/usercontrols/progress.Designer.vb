<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class progress
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblpercent = New System.Windows.Forms.Label
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.lblcount = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblpercent, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pb, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblcount, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(399, 30)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblpercent
        '
        Me.lblpercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblpercent.AutoSize = True
        Me.lblpercent.Location = New System.Drawing.Point(302, 7)
        Me.lblpercent.Name = "lblpercent"
        Me.lblpercent.Size = New System.Drawing.Size(94, 16)
        Me.lblpercent.TabIndex = 2
        Me.lblpercent.Text = "0.00%"
        Me.lblpercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb
        '
        Me.pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb.Location = New System.Drawing.Point(3, 3)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(193, 24)
        Me.pb.TabIndex = 0
        '
        'lblcount
        '
        Me.lblcount.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcount.AutoSize = True
        Me.lblcount.Location = New System.Drawing.Point(202, 7)
        Me.lblcount.Name = "lblcount"
        Me.lblcount.Size = New System.Drawing.Size(94, 16)
        Me.lblcount.TabIndex = 1
        Me.lblcount.Text = ".../..."
        Me.lblcount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'progress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "progress"
        Me.Size = New System.Drawing.Size(399, 30)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents lblpercent As System.Windows.Forms.Label
    Friend WithEvents lblcount As System.Windows.Forms.Label

End Class
