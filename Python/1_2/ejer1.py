#Hacer un programa que permita ingresar dos números, y muestre la multiplicación de ambos
''' while True:
    a= input("Ingrese el primer número:")
    b= input("Ingrese el segundo número:")
    try: 
        c=int(a)*int(b)
        break
    except:
        print("Debe ser solo número")
        continue

print(a,"x",b," resulta ", c)
     '''

#Hacer un programa que permita ingresar tres números, y muestre en pantalla tanto la suma como la multiplicación de ellos

''' while True:
    a= input("Ingrese el primer número:")
    b= input("Ingrese el segundo número:")
    c= input("Ingrese el tercer número:")
    try:
        suma=int(a)+int(b)+int(c)
        product=int(a)*int(b)*int(c)
        break
    except:
        print("Debe ser solo número")
        continue

print("La suma de los números ingresados es",suma,"\n y el producto es", product) '''

#Confeccione un programa que lea un número e indique si este es positivo o negativo
''' while True:
    a= input("Ingrese un número :")
    try:
        number=int(a)
        if number<0:
            print(number, " es negativo")
        elif number>0:
            print(number," es positivo")
        else:
            print(number)
        continue
    except:
        print("Debe ser solo número")
        continue '''

#Confeccione un programa que lea un número e indique si este es par o impar
''' while True:
    a= input("Ingrese un número :")
    try:
        number=int(a)
        if number%2==0:
            print(number, " es par")
        else:
            print(number, " es impar")
        continue
    except:
        print("Debe ser solo número")
        continue '''

#Confeccione un programa que lea un número e indique si este es par-positivo, par-negativo, impar-positivo o impar-negativo
''' while True:
    a= input("Ingrese un número (0 para salir):")
    try:
        number=int(a)
        if number%2==0 and number>0:
            print(number, " es par-positivo")
        elif number%2==0 and number<0:
            print(number, " es par-negativo")
        elif number%2!=0 and number>0:
            print(number, " es impar-positivo")
        elif number%2!=0 and number<0:
            print(number, " es impar-negativo")
        else:
            break
        continue
    except:
        print("Debe ser solo número")
        continue '''

#Confeccione un programa que lea un número y si este es mayor o igual a 10 devuelva el triple de este, de lo contrario la cuarta parte de este
''' while True:
    a= input("Ingrese un número (0 para salir):")
    try:
        number=float(a)
        if number==0:
            break
        elif number>=10 :
            print(number, " multiplicado por 3 resulta", number*3)
        elif number<10:
            print("La cuarta parte de ", number, " resulta", number/4)
        continue
    except:
        print("Debe ser solo número")
        continue '''
#Obtener el IVA de una y si esta es superior de G 150.000 aplicar un descuento del 25%
''' descuento=0
iva=0
while True:
    a= input("Ingrese una cifra (Enter para salir):")
    if a=='':
        break
    try:
        number=float(a)
        iva=number*0.1
        print("El IVA de ",number," es ", iva)
        if iva>150000:
            descuento=iva*0.25
            print("Y el descuento al 25'%' es",descuento,". EL IVA resultante es", iva-descuento)
        continue
    except:
        print("Debe ser solo número")
        continue '''
