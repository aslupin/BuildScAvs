
Public Class Form2
    Dim Form1 As Object
    Dim j As Long
    Dim K As Long

    'Open file vsfilter-aegisub32.dll with Aegisub
    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myFileDlog1 As New OpenFileDialog()
        myFileDlog1.InitialDirectory = "d:\"
        myFileDlog1.Filter = "All Files (*.*)|*.*" & _
            "|DLL Files (*.dll)|*.dll"
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
        ' My.Settings.TextToSave1 = TextBox1.Text


    End Sub
    'Open file Convolution3DYV12.dll with MeGui
    'TextBox5.Text
    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim myFileDlog2 As New OpenFileDialog()
        myFileDlog2.InitialDirectory = "d:\"
        myFileDlog2.Filter = "All Files (*.*)|*.*" & _
            "|DLL Files (*.dll)|*.dll"
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
        ' My.Settings.TextToSave2 = TextBox2.Text
    End Sub
    'Open file VSFilter.dll with MeGui
    'Button 3
    Public Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim myFileDlog2 As New OpenFileDialog()
        myFileDlog2.InitialDirectory = "d:\"
        myFileDlog2.Filter = "All Files (*.*)|*.*" & _
            "|DLL Files (*.dll)|*.dll"
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
        TextBox3.Text = myFileDlog2.FileName
        '   My.Settings.TextToSave3 = TextBox3.Text
    End Sub

    'Load File Setting
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.TextToSave1
        TextBox2.Text = My.Settings.TextToSave2
        TextBox3.Text = My.Settings.TextToSave3
        'TextBox4.Text = My.Settings.TextToSave4
        ' Me.CheckBox1.Checked = My.Settings.chk2

    End Sub
    'save Plugin DF
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        My.Settings.TextToSave1 = TextBox1.Text
        My.Settings.TextToSave2 = TextBox2.Text
        My.Settings.TextToSave3 = TextBox3.Text
        Dim msg = "complete"
        MsgBox(msg)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim msg2 = "HELP" & Environment.NewLine & _
              "" & Environment.NewLine & _
              "การใช้ Setting จะมีผลกับเเค่การใช้แบบ Pro Fansub Style" & Environment.NewLine & _
              "ที่อยู่ของ Plug-in จะหาได้ดังนี้" & Environment.NewLine & _
              "" & Environment.NewLine & _
              "vsfilter-aegisub32.dll" & Environment.NewLine & _
              "\Aegisub\csri\vsfilter-aegisub32.dll" & Environment.NewLine & _
              "Convolution3DYV12.dll" & Environment.NewLine & _
               "\MeGui\tools\avisynth_plugin\Convolution3DYV12.dll" & Environment.NewLine & _
               "VSFilter.dll" & Environment.NewLine & _
               "\MeGui\tools\avisynth_plugin\VSFilter.dll" & Environment.NewLine & _
               "" & Environment.NewLine & _
               "ถ้ามี Plug-in ที่ดีกว่าหรือถนัดกว่าสามารถใช้เเทนได้เลย ตัวโปรเเกรมไม่ได้กำหนดตายตัว" & Environment.NewLine & _
               "ใครไม่มี Plug-in ตัวไหนให้ทำการโหลดจาก Google เอาได้หรือติดต่อทางเพจ"
        MsgBox(msg2, MsgBoxStyle.OkOnly, AcceptButton)
    End Sub
End Class