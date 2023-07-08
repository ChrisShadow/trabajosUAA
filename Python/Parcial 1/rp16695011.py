#Enunciado 1
''' while True:
    a= input("Ingrese un número(Enter para salir):")
    b= input("Ingrese el segundo número(Enter para salir): ")
    c= input("Ingrese el tercer número(Enter para salir): ")
    if a=='' or b=='' or c=='':
        print("--Programa finalizado--")
        break
    try:
        A=float(a)
        B=float(b)
        C=float(c)
        suma=A+B+C
        print("La suma de los valores ingresados es: ", suma)
        continue
    except:
        print("Debe ser solo número")
        continue '''

#Enunciado 2
''' while True:
    a= input("Ingrese la primera nota(Enter para salir):")
    b= input("Ingrese la segunda cifra(Enter para salir): ")
    c= input("Ingrese la tercera cifra(Enter para salir): ")
    d= input("Ingrese la cuarta cifra(Enter para salir): ")
    e= input("Ingrese la quinta cifra(Enter para salir): ")
    if a=='' or b=='' or c=='' or d=='' or e=='':
        print("--Programa finalizado--")
        break
    try:
        A=float(a)
        B=float(b)
        C=float(c)
        D=float(d)
        E=float(e)
        print("La nota acumulada es ", A+B+C+D+E)
        notaP=(A+B+C+D+E)/5
        print("Entonces, la nota promedio entre : \n", A,"\n",B,"\n",C,"\n",D,"\n y",E," es ", notaP) 
        continue
    except:
        print("Debe ser solo número")
        continue '''

#Enunciado 3
''' while True:
    a= input("Ingrese un número (0 para salir):")
    try:
        number=int(a)
        if number%2!=0 and number<0:
            print(number, " es impar-negativo")
        elif number==0:
            print("--Programa finalizado--")
            break
        else:
            print(number," no cumple con las condiciones")
        continue
    except:
        print("Debe ser solo número")
        continue '''

#Enunciado 4

while True:
    a= input("Ingrese una cifra(Enter para salir): ")
    if a=='':
        print("--Programa finalizado--")
        break
    try:
        A=float(a)
        if(A>=600000 ):
            descuento=A-(A*0.25)
            print("La cifra ingresada (",A,") con el descuento del 25%'",A*0.25," corresponde a: ", descuento," $ americanos")
        elif( A>=290000 and A<600000 ):
            descuento=A-(A*0.1)
            print("La cifra ingresada (",A,") con el descuento del 10%'",A*0.1," corresponde a: ", descuento," $ americanos")
        else:
            print(A, " no tiene descuento.")
        continue
    except:
        print("Debe ser solo número")
        continue