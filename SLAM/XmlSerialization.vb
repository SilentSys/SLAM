Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization

Public Class XmlSerialization

    Public Shared Function Serialize(Of T)(obj As T) As String
        Dim serializer = New DataContractSerializer(obj.[GetType]())
        Using writer = New StringWriter()
            Using stm = New XmlTextWriter(writer)
                serializer.WriteObject(stm, obj)
                Return writer.ToString()
            End Using
        End Using
    End Function

    Public Shared Function Deserialize(Of T)(serialized As String) As T
        Dim serializer = New DataContractSerializer(GetType(T))
        Using reader = New StringReader(serialized)
            Using stm = New XmlTextReader(reader)
                Return DirectCast(serializer.ReadObject(stm), T)
            End Using
        End Using
    End Function

End Class
