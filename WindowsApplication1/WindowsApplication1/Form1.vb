Imports System.IO

Public Class Form1
    Dim i As Long
    Dim j As Long
    Dim Plugin1 As String
    Dim Plugin2 As String
    Dim Plugin3 As String
    Dim Plugin4 As String
    Dim Form2 As Object
    'Check Style Fansub  
    'i ++
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
#If i = 0 Then
        i = i + 1
#End If
        My.Settings.chk1 = Me.CheckBox2.CheckState
    End Sub
    'Open file MP4 || MKV
    'TextBox1.Text
    'Button 1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myFileDlog1 As New OpenFileDialog()
        myFileDlog1.InitialDirectory = "d:\"
        myFileDlog1.Filter = "All Files (*.*)|*.*" & _
            "|MP4 Files (*.mp4)|*.mp4" & _
            "|MKV Files (*.mkv)|*.mkv"
        myFileDlog1.FilterIndex = 2
        myFileDlog1.RestoreDirectory = True
        If myFileDlog1.ShowDialog() = _
            DialogResult.OK Then
            If Dir(myFileDlog1.FileName) <> "" Then
                MsgBox("File Exists: " & _
                       myFileDlog1.FileName, _
                       MsgBoxStyle.Information)
            Else
                MsgBox("File Not Found", _
                       MsgBoxStyle.Critical)
            End If
        End If
        TextBox1.Text = myFileDlog1.FileName
        '    TextBox1.Text = My.Settings.TextToSave
    End Sub
    'Open file ASS
    'TextBox2.Text
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim myFileDlog2 As New OpenFileDialog()
        myFileDlog2.InitialDirectory = "d:\"
        myFileDlog2.Filter = "All Files (*.*)|*.*" & _
            "|ASS Files (*.ass)|*.ass"
        myFileDlog2.FilterIndex = 2
        myFileDlog2.RestoreDirectory = True
        If myFileDlog2.ShowDialog() = _
            DialogResult.OK Then
            If Dir(myFileDlog2.FileName) <> "" Then
                MsgBox("File Exists: " & _
                       myFileDlog2.FileName, _
                       MsgBoxStyle.Information)
            Else
                MsgBox("File Not Found", _
                       MsgBoxStyle.Critical)
            End If
        End If
        TextBox2.Text = myFileDlog2.FileName
    End Sub
    'Load File
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        j = My.Settings.Jcount
        If i Mod 2 = 0 Then
            Dim LoadTextSub As String = "LoadPlugin(""C:\Encode Plugin\vsfilter-aegisub32.dll"")" & Environment.NewLine & _
                                    "LoadPlugin(""C:\Encode Plugin\Convolution3DYV12.dll"")" & Environment.NewLine & _
                                    "LoadPlugin(""C:\Encode Plugin\VSFilter.dll"")" & Environment.NewLine & _
                                    "DirectShowSource(""" + TextBox1.Text & _
                                    """, fps=23.976, audio=false, convertfps=true)" & Environment.NewLine & _
                                    "" & Environment.NewLine & _
                                    "Convolution3D(""animeHQ"") # Heavy Noise" & Environment.NewLine & _
                                    "TextSub(""" + TextBox2.Text & _
                                    """,1)"
            TextBox3.Text = LoadTextSub
        End If
        If i Mod 2 = 1 Then
            Plugin1 = My.Settings.TextToSave1
            Plugin2 = My.Settings.TextToSave2
            Plugin3 = My.Settings.TextToSave3
            Dim LoadTextSub As String = "LoadPlugin(""" + Plugin1 & _
                          """)" & Environment.NewLine & _
                          "LoadPlugin(""" + Plugin2 & _
                          """)" & Environment.NewLine & _
                          "LoadPlugin(""" + Plugin3 & _
                          """)" & Environment.NewLine & _
                         "DirectShowSource(""" + TextBox1.Text & _
                                    """, fps=23.976, audio=false, convertfps=true)" & Environment.NewLine & _
                                    "" & Environment.NewLine & _
                                    "Convolution3D(""animeHQ"") # Heavy Noise" & Environment.NewLine & _
                                    "TextSub(""" + TextBox2.Text & _
                                    """,1)"
            TextBox3.Text = LoadTextSub
        End If
    End Sub
    'Save as
    'Button 4
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "All files (*.*)|*.*|AVS files (*.avs)|*.avs"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sw As StreamWriter = New StreamWriter(saveFileDialog1.OpenFile())
            If (sw IsNot Nothing) Then
                sw.WriteLine(TextBox3.Text)
                sw.Close()
            End If
        End If
    End Sub
    'Show Log Msg
    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MsgBox(TextBox3.Text)
    End Sub
    '
    '----------------- Tab --------------
    '
    'Settings
    'Private Sub SettingsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem1.Click
    Private Sub SettingsPluginsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsPluginsToolStripMenuItem.Click
        Dim oForm As Form2
        oForm = New Form2()
        oForm.Show()
        oForm = Nothing
    End Sub
    'How to
    Private Sub HowToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HowToToolStripMenuItem.Click
        Dim msg2 = "How to  ||AS Encode" & Environment.NewLine & _
       "" & Environment.NewLine & _
       "Rookie Fansub Style" & Environment.NewLine & _
       "1.ใส่ไฟล์ raw ที่มีนามสกุล .mp4 หรือ .mkv" & Environment.NewLine & _
       "2.ใส่ไฟล์ subtitle ที่มีนามสกุล .ass (ไฟล์ที่ save ได้จาก Aegisub)" & Environment.NewLine & _
       "3.กด Run เพื่อที่จะสั่งให้ทำการเขียน script" & Environment.NewLine & _
       "4.กด Save as..  เพื่อ save ไฟล์ avs" & Environment.NewLine & _
        "คำเเนะนำ : ให้นำโฟเดอร์ Encode Plugin วางไว้ที่ C:\ เพื่อให้ตัวโปรเเกรมเรียกใช้ได้" & Environment.NewLine & _
        "" & Environment.NewLine & _
        "Pro Fansub Style" & Environment.NewLine & _
        "ติ๊กช่อง Pro Fansub Style เพื่อเรียกใช้งาน " & Environment.NewLine & _
        "ให้เข้าไปที่ Settings > Settings Plug-ins เพื่อกำหนดปลายทาง Plug-ins ของท่าน" & Environment.NewLine & _
         "1.ใส่ไฟล์ raw ที่มีนามสกุล .mp4 หรือ .mkv" & Environment.NewLine & _
       "2.ใส่ไฟล์ subtitle ที่มีนามสกุล .ass (ไฟล์ที่ save ได้จาก Aegisub)" & Environment.NewLine & _
       "3.กด Run เพื่อที่จะสั่งให้ทำการเขียน script" & Environment.NewLine & _
       "4.กด Save as..  เพื่อ save ไฟล์ avs" & Environment.NewLine & _
       "" & Environment.NewLine & _
        "หมายเหตุ : สามารถดู script ได้จากปุ่ม ... หลัง Show Log"


        MsgBox(msg2, MsgBoxStyle.OkOnly, AcceptButton)
    End Sub
    'ZIXMAR+Fs
    Private Sub ZIXMARFsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZIXMARFsToolStripMenuItem.Click
        Dim msg = "ZIXMAR+FS" & Environment.NewLine & _
            "Facebook : We're OTAKU Zixmar+" & Environment.NewLine & _
            "Website  : www.zixmarplus.com" & Environment.NewLine & _
            "--------------------" & Environment.NewLine & _
            "Programming and Design : AsLupin"
        MsgBox(msg)
    End Sub
    '
    '-----------------FC Aotomatic-------------
    '
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckBox2.Checked = My.Settings.chk1
        '  Me.CheckBox1.Checked = My.Settings.chk2
        Plugin1 = My.Settings.TextToSave1
        Plugin2 = My.Settings.TextToSave2
        Plugin3 = My.Settings.TextToSave3
    End Sub

    Private Sub EncodePluginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncodePluginToolStripMenuItem.Click
        Dim URL As String = "http://www.zixmarplus.com/Encode%20Plugin.rar"
        DownloadFile(URL)
    End Sub
    Sub DownloadFile(ByVal URL As String)
        Dim SFD As New SaveFileDialog
        SFD.Filter = "All Files|*.*"
        SFD.FileName = "Encode Plugin.rar"
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using w As New Net.WebClient
                w.DownloadFile(URL, SFD.FileName)
            End Using
        End If
    End Sub
    Private Sub ASEncodeVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASEncodeVToolStripMenuItem.Click
        Dim URL As String = "http://www.zixmarplus.com/AS%20Encode.rar"
        DownloadFile2(URL)
    End Sub
    Sub DownloadFile2(ByVal URL As String)
        Dim SFD As New SaveFileDialog
        SFD.Filter = "All Files|*.*"
        SFD.FileName = "AS Encode.rar"
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using w As New Net.WebClient
                w.DownloadFile(URL, SFD.FileName)
            End Using
        End If
    End Sub
End Class
