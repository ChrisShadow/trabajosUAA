
''' A- imprima un menú de operaciones desde un diccionario:
Opciones: 1-Calculo de IVA, 2- Numero mayor, 3-Calculo de descuento, 
4-Par o impar, 99-Final
B- Solicite el ingreso de una Opciones
C- Dada la opcion, ejcutar la porción de programa que corresponda
1- Ingresa un monto y calcule el valor del IVA (10%)
2- Ingrese 2 números, imprima ambos e indique cual es el mayor
3- Ingrese un monto y calcule un descuento del 10% sobre el mismo si el valor 
es mayor o igual a 10,000 y menor o igaual a 20,000, 20% si es mayor a 20,000 y menor o igual a 50,000 y 30%
si el valor es mayor a 50,000. Imprima el monto ingresado, el valor del descuento y el monto final.
4- Confeccione un programa qe lea un número e indique si este es par o impar.
 '''

opciones={1:'Cálculo de IVA',2:'Número Mayor',3:'Cálculo descuento',4:'Par o impar', 99:'Finalizar programa'}
while True:
    print("--MENÚ DE OPERACIONES--")
    for k,v in opciones.items():
        print("  ",k,v)
    dato=input("Ingrese una opción a ejecutar:")
    try:
        opcion=int(dato)
        if opcion==1:
            uno=input("Ingrese un monto:")
            try:
                u=float(uno)
                print("El IVA de: ", u," es ", u*0.1,"\n")
            except:
                print("Debe ser solo número. Intente de vuelta\n\n")
            continue
        elif opcion==2:
            uno=input("Ingrese el primer número:")
            dos=input("Ingrese el segundo número:")
            try:
                u=float(uno)
                d=float(dos)

                if u>d:             
                    print(u, " es mayor a ", d,"\n")
                else: 
                    print(d, " es mayor a ", u,"\n")
            except:
                print("Debe ser solo número. Intente de vuelta\n\n")
            continue
        elif opcion==3:
            uno=input("Ingrese un monto:")
            try:
                u=float(uno)
                if u>=10000 and u<=20000:
                    print("El IVA de ", u ," es", u*0.1,".\nEl descuento correspondiente es",u-(u*0.1) ,"\n")
                elif u>20000 and u<=50000:
                    print("El 20%' de ", u ," es", u*0.2,".\nEl descuento correspondiente es",u-(u*0.2) ,"\n")
                elif u>50000:
                    print("El 30%' de ", u ," es", u*0.3,".\nEl descuento correspondiente es",u-(u*0.3) ,"\n")
            except:
                print("Debe ser solo número. Intente de vuelta\n\n")
            continue
        elif opcion==4:
            a= input("Ingrese un número :")
            try:
                number=int(a)
                if number%2==0:
                    print(number, " es par")
                else:
                    print(number, " es impar")
            except:
                print("Debe ser solo número. Intente de vuelta\n\n")
            continue
        elif opcion==99:
            print("--Programa finalizado--")
            break
        else:
            print("No corresponde.Intente de vuelta\n")
            continue
    except:
        print("Debe ser solo número. Intente de vuelta\n\n")
        continue 
