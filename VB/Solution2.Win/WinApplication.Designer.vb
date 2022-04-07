Namespace Solution2.Win

    Partial Class Solution2WindowsFormsApplication

        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Component Designer generated code"
        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
            Me.module3 = New Solution2.[Module].Solution2Module()
            Me.validationWindowsFormsModule1 = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
            Me.validationModule1 = New DevExpress.ExpressApp.Validation.ValidationModule()
            CType((Me), System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' validationModule1
            ' 
            Me.validationModule1.AllowValidationDetailsAccess = True
            Me.validationModule1.IgnoreWarningAndInformationRules = False
            ' 
            ' Solution2WindowsFormsApplication
            ' 
            Me.ApplicationName = "Solution2"
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.validationModule1)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.validationWindowsFormsModule1)
            AddHandler Me.DatabaseVersionMismatch, New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(AddressOf Me.Solution2WindowsFormsApplication_DatabaseVersionMismatch)
            AddHandler Me.CustomizeLanguagesList, New System.EventHandler(Of DevExpress.ExpressApp.CustomizeLanguagesListEventArgs)(AddressOf Me.Solution2WindowsFormsApplication_CustomizeLanguagesList)
            CType((Me), System.ComponentModel.ISupportInitialize).EndInit()
        End Sub

'#End Region
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule

        Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule

        Private module3 As Solution2.[Module].Solution2Module

        Private validationWindowsFormsModule1 As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule

        Private validationModule1 As DevExpress.ExpressApp.Validation.ValidationModule
    End Class
End Namespace
