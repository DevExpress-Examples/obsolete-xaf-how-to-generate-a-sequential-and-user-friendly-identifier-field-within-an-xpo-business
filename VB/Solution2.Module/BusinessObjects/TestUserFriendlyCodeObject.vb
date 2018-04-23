Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Solution2.Module.BusinessObjects
    <DefaultClassOptions> _
    Public Class TestUserFriendlyCodeObject
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        <NonCloneable, RuleUniqueValue, Indexed(Unique := True)> _
        Public Property Code() As String
            Get
                Return GetPropertyValue(Of String)("Code")
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Code", value)
            End Set
        End Property
        Protected Overrides Sub OnSaving()
            If Not(TypeOf Session Is NestedUnitOfWork) AndAlso (Session.DataLayer IsNot Nothing) AndAlso Session.IsNewObject(Me) AndAlso (TypeOf Session.ObjectLayer Is SimpleObjectLayer) AndAlso String.IsNullOrEmpty(Code) Then
                        'OR
                        '&& !(Session.ObjectLayer is DevExpress.ExpressApp.Security.ClientServer.SecuredSessionObjectLayer)
                Dim nextSequence As Integer = DistributedIdGeneratorHelper.Generate(Session.DataLayer, Me.GetType().FullName, "MyServerPrefix")
                Code = String.Format("N{0:D6}", nextSequence)
            End If
            MyBase.OnSaving()
        End Sub
    End Class
End Namespace
