#Leer tres números e imprimir el mayor de ellos
''' while True:
    mayor=0
    a= input("Ingrese un número(Enter para salir):")
    b= input("Ingrese el segundo número(Enter para salir): ")
    c= input("Ingrese el tercer número(Enter para salir): ")
    if a=='' or b=='' or c=='':
        break
    try:
        A=float(a)
        B=float(b)
        C=float(c)
        if A > mayor  and B<A and C<A:
            mayor=A
        elif  B > mayor  and A<B and C<B:
            mayor=B
        else:
            mayor=C
        break
    except:
        print("Debe ser solo número")
        continue

print("El mayor de los números ingresadoe es: ", mayor) '''

#----
''' Determine el valor de un pasaje en avión , conociendo la distancia a recorrer, el número de
días de estancia, y sabiendo que si la distancia a recorrer es superior a 1000 Km y el número
de días de estancia es superior a 7, la línea aérea le hace un descuento del 30%. ( el precio
por km. es de 20.000Gs) '''

''' pasaje=0
descuento=0
while True:
    distancia= input("Ingrese la distancia a reocorrer(Enter para salir): ")
    diasEstancia=input("Ingrese la cantidad de días de estadía(Enter para salir): ")
    if distancia=='' or diasEstancia=='':
        break
    try:
        d=float(distancia)
        e=float(diasEstancia)
        if(d>1000 and e>7):
            d=d*20000
            descuento=d*0.3
            pasaje=d-descuento
        print("El precio actual equivale a ",d*20000," Gs")
        break
    except:
        print("Debe ser solo número")
        continue 
print("El pasaje con el descuento del 30'%' corresponde a: ", pasaje," Gs") '''


#----
''' Confeccione un programa que permita determinar el precio de un pasaje en avión sabiendo
que:
♦ valor por kilómetro recorrido es de ($47)
♦ sobre los 1000 km de vuelo el valor del kilómetro es de $25 '''

''' pasaje=0
while True:
    distancia= input("Ingrese la distancia a reocorrer(Enter para salir): ")
    if distancia=='':
        break
    try:
        d=float(distancia)
        if(d>1000):
            d=d*25
            pasaje=d
            print("El precio actual equivale a ",pasaje," $")
        else:
            print("El precio actual equivale a ",d*47," $")
        continue
    except:
        print("Debe ser solo número")
        continue  '''


#----
''' Construya un programa que permita obtener el sueldo liquido y descuento previsional de un
trabajador, conociendo su sueldo bruto y se le descontará el 10% del sueldo bruto por IPS '''

''' while True:
    sueldoB= input("Ingrese el sueldo bruto del trabajador(Enter para salir): ")
    if sueldoB=='':
        break
    try:
        s=float(sueldoB)
        descuento=s*0.1
        print("El descuento correspondiente al 10%' de ",s,", equivalea ",descuento,". \nEntonces el sueldo líquido equivale a ", s-descuento)
        continue
    except:
        print("Debe ser solo número")
        continue '''


#---
''' Crear un programa que proporcione el precio medio de un producto a partir del precio en
tres establecimientos distintos '''
''' while True:
    a= input("Ingrese el precio del primer producto(Enter para salir):")
    b= input("Ingrese la segunda cifra(Enter para salir): ")
    c= input("Ingrese la tercera cifra(Enter para salir): ")
    if a=='' or b=='' or c=='':
        break
    try:
        A=float(a)
        B=float(b)
        C=float(c)
        print("El precio acumulado es ", A+B+C)
        precioP=(A+B+C)/3
        print("Entonces, el precio promedio entre : \n", A,"\n",B,"\ny ",C," es ", precioP) 
        continue
    except:
        print("Debe ser solo número")
        continue '''

#---
''' Desarrollar un programa que lea cuatro números y a continuación imprima el mayor de los
cuatro '''


''' while True:
    mayor=0
    a= input("Ingrese un número(Enter para salir):")
    b= input("Ingrese el segundo número(Enter para salir): ")
    c= input("Ingrese el tercer número(Enter para salir): ")
    d= input("Ingrese el cuarto número(Enter para salir): ")
    if a=='' or b=='' or c=='' or d=='':
        break
    try:
        A=float(a)
        B=float(b)
        C=float(c)
        D=float(d)
        if A > mayor  and B<A and C<A and D<A:
            mayor=A
        elif  B > mayor  and A<B and C<B and D<B:
            mayor=B
        elif C>mayor and A<C and B<C and D<C:
            mayor=C
        else:
            mayor=D
        print("El mayor de los números ingresadoe es: ", mayor)
        continue
    except:
        print("Debe ser solo número")
        continue '''

#---
''' Escribir un programa que solicite al usuario introducir dos números. Si el primer numero
introducido es mayor que el segundo numero, el programa debe imprimir el mensaje "El
primer numero es el mayor", en caso contrario deber imprimir el mensaje opuesto.
Considere el caso de que ambos números sean iguales e imprima el correspondiente
mensaje. '''

''' while True:
    mayor=0
    a= input("Ingrese un número(Enter para salir):")
    b= input("Ingrese el segundo número(Enter para salir): ")
    if a=='' or b=='':
        break
    try:
        A=float(a)
        B=float(b)
        if A > B:
            print(A," es mayor que ",B)
        elif  B > A:
            print(B," es mayor que ",A)
        else:
            print(A," y ", B,"están igualados.")
        continue
    except:
        print("Debe ser solo número")
        continue '''

#---
''' Determinar el precio de un billete de ida y vuelta en ferrocarril, conociendo la distancia a
recorrer y la distancia superior a 800 kilómetros el billete tiene una reducción del 30. El
precio por kilómetro es de 2.5 dolares. '''

''' pasaje=0
descuento=0
while True:
    distancia= input("Ingrese la distancia a reocorrer(Enter para salir): ")
    if distancia=='':
        break
    try:
        d=float(distancia)
        if(d>800):
            d=d*2.5
            descuento=d*0.3
            pasaje=d-descuento
            print("El pasaje(",d,") con el descuento del 30%'",descuento," corresponde a: ", pasaje," $ americanos")
        else:
            print("El precio actual equivale a ",d*2.5," $ americanos")
        continue
    except:
        print("Debe ser solo número")
        continue  '''


#----
''' Diseñar un programa en el que a partir de una fecha introducida por teclado con el formato
DIA, MES, AÑO se obtenga la fecha del día siguiente. '''
''' def fecha_dia_siguiente(dia, mes, anho):
    bisiesto= False

    if anho % 400==0:
        bisiesto=True
    elif anho % 4==0:
        bisiesto=True

    if mes in (1,3,5,7,8,10,12):
        dia_mes=31
    elif mes == 2:
        if bisiesto: 
            dia_mes=29
        else:
            dia_mes=28
    else:
        dia_mes=30
    
    if dia < dia_mes:
        dia +=1
    else:
        dia=1
        if mes == 12:
            mes = 1
            anho +=1
        else:
            mes+=1

    return (dia , mes , anho)

date=''
while date=='':
    date= input("Ingrese una fecha en dd/mm/AAAA(Enter para salir): ")
    
    if date=='':
        print("--Programa finalizado--")
        break

    try:
        split= date.split("/")
        print(split,". Por lo tanto...")
        day=int(split[0])
        month=int(split[1])
        year=int(split[2])
        fecha_siguiente= fecha_dia_siguiente(day, month, year)
        print("La fecha siguiente a la fecha ingresada es ", fecha_siguiente)
        date=''
        continue
    except:
        print("Intente de vuelta.")
        date=''
        continue '''


#-----
#Obtener el iva de una compra y encontrar el valor final a pagar. 

''' while True:
    precio= input("Ingrese la cifra a pagar(Enter para salir): ")
    if precio=='':
        print("--Programa finalizado--")
        break
    try:
        p=float(precio)
        descuento=p*0.1
        total=p-descuento
        print("El precio equivalente es ",total," Gs. ya que el IVA corresponde a los ", descuento)
        continue
    except:
        print("Debe ser solo número")
        continue
 '''
#----
''' Realizar un programa que averigüe si dados dos números introducidos por teclado uno es 
divisor del otro. '''

''' while True:
    a= input("Ingrese un número(Enter para salir):")
    b= input("Ingrese el segundo(Enter para salir): ")
    if a=='' or b=='':
        print("--Programa finalizado--")
        break
    try:
        A=float(a)
        B=float(b)
        print(A," dividio ",B, " resulta ", A/B, ". Por lo tanto...")
        if A%B!=0:
            print("Los números ingresados no son divisores entre sí.")
        elif A>=B or A<=B and A%B==0:
            print(B," es divisor de ",A)
        continue
    except:
        print("Debe ser solo número")
        continue '''

#----
#Se requiere convertir una cantidad ingresada en kilogramos a gramos
''' while True:
    kg= input("Ingrese una cifra en Kg(Enter para salir):")
    if kg=='':
        print("--Programa finalizado--")
        break
    try:
        kg=float(kg)
        print(kg, "kg en unidades de gramos resulta ", kg*1000,"g")
        continue
    except:
        print("Debe ser solo número")
        continue  '''

#----
''' Realice un programa para determinar si un número es el uno, el dos, el tres o no es ninguno 
de ellos.  '''
''' while True:
    number= input("Ingrese una cifra(Enter para salir):")
    if number=='':
        print("--Programa finalizado--")
        break
    try:
        n=int(number)
        if n ==1:
            print("UNO")
        elif n==2:
            print("DOS")
        elif n==3:
            print("TRES")
        else:
            print(n, " es distinto de UNO,DOS o TRES")
        continue
    except:
        print("Debe ser solo número")
        continue
 '''
#---
''' Dada una variable cuyo valor es leído desde teclado, imprima por pantalla si el número es o 
no mayor que 0 '''
''' while True:
    number= input("Ingrese una cifra(Enter para salir):")
    if number=='':
        print("--Programa finalizado--")
        break
    try:
        n=int(number)
        if n >0:
            print(n," es mayor a 0")
        elif n<0:
            print(n," no es mayor a 0")
        else:
            print("CERO")
        continue
    except:
        print("Debe ser solo número")
        continue
 '''

#----
''' Dada una variable cuyo valor es leído desde teclado, imprima por pantalla si el número es 
o no par o impar. '''
''' while True:
    number= input("Ingrese una cifra(Enter para salir):")
    if number=='':
        print("--Programa finalizado--")
        break
    try:
        n=float(number)
        if n%2==0:
            print(n," es par")
        else:
            print(n, " es impar")
        continue
    except:
        print("Debe ser solo número")
        continue
 '''
#---

'''Tras leer un carácter desde teclado, imprima por pantalla si la letra es mayúscula o 
minúscula. Amplíe el programa, indicando si el carácter es un dígito numérico. '''

dato=''
while dato=='':
    dato= input("Ingrese letra(m/M)  o número(Enter para finalizar): ")
    
    if dato=='':
        print("--Programa finalizado--")
        break

    try:
        if dato.isnumeric():
            print(dato, " es de tipo númerico")
        elif dato.islower():
            print(dato, " está en minúscula")
        elif dato.isupper():
            print(dato, " está en mayúscula")
        else:
            print("No corresponde")
        dato=''
        continue
    except:
        print("Intente de vuelta.")
        dato=''
        continue 