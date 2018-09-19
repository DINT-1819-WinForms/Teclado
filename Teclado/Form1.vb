﻿Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Para cada uno de los números que tenemos que añadir...
        For contador As Integer = 0 To 9
            'Creamos un nuevo botón
            Dim boton As New Button

            'Configuramos el botón
            boton.Text = contador.ToString()
            boton.Dock = DockStyle.Fill
            boton.Name = contador.ToString() & "Button"
            boton.Tag = contador

            'Le asociamos el manejador de eventos
            AddHandler boton.Click, AddressOf Button_Click

            'Obtenemos una posición libre en la tabla y lo insertamos
            Dim fila, columna As Integer
            ObtenerPosicion(fila, columna)
            TableLayoutPanel1.SetRow(boton, fila)
            TableLayoutPanel1.SetColumn(boton, columna)
            TableLayoutPanel1.Controls.Add(boton)
        Next

    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        'Añadimos en el TextBox el número pulsado
        NumeroTextBox.Text &= DirectCast(sender, Button).Tag.ToString()
    End Sub

    Private Sub ObtenerPosicion(ByRef fila As Integer, ByRef columna As Integer)
        Dim aleatorio As New Random

        'Hacemos el bucle mientras que la posición aleatoria no sea válida (este ocupada o sea una posición no permitida)
        Do
            'Obtenemos una fila y columna aleatoria
            fila = aleatorio.Next(4)
            columna = aleatorio.Next(3)
        Loop While (TableLayoutPanel1.GetControlFromPosition(columna, fila) IsNot Nothing) Or (fila = 3 And (columna = 0 Or columna = 2))

    End Sub
End Class
