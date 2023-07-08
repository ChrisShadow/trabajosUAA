
''' A- Imprima un menú de opciones desde una lista
Opciones: 1-Multiplicación de 2 números, 2-Suma y multiplicación de 3 números,
3-Número positivo o negativo, 4-Par o impar, 99-Volver al menú
B-Solicite el ingreso de una opciónam
C- Dada la opción ejecutar la porción de programa que corresponda:
1. Hacer un programa que permita ingresar dos números, y muestre el producto de ambos.
2. Hacer un programa que permita ingresar tres números, y muestre en pantalla tanto la suma 
como el producto de ellos.
3. Confeccione un programa que lea un número e indique si este es positivo o negativo
4. Confeccione un programa que lea un número e indique si este es par o impar '''

opciones=['1-Producto de 2 números', '2-Suma y producto de 3 números', '3-Número positivo o negativo', '4-Par o impar', "99-Finalizar programa"]
while True:
    print("--MENÚ DE OPERACIONES--")
    for e in opciones:
        print("  ",e)
    dato=input("Ingrese una opción a ejecutar:")
    try:
        opcion=int(dato)
        if opcion==1:
            uno=input("Ingrese el primer número:")
            dos=input("Ingrese el segundo número:")
            try:
                u=float(uno)
                d=float(dos)
                print("La suma entre ambos da: ", u+d,"\n")
            except:
                print("Debe ser solo número. Intente de vuelta\n\n")
            continue
        elif opcion==2:
            uno=input("Ingrese el primer número:")
            dos=input("Ingrese el segundo número:")
            tres=input("Ingrese el tercer número:")
            try:
                u=float(uno)
                d=float(dos)
                t=float(tres)
                print("La suma entre ellos es ", u+d+t," y el producto resulta ",u*d*t,"\n")
            except:
                print("Debe ser solo número. Intente de vuelta\n\n")
            continue
        elif opcion==3:
            uno=input("Ingrese el primer número:")
            try:
                u=float(uno)
                if u<0:
                    print(u," es negativo\n")
                elif u>0:
                    print(u," es positivo\n")
                else:
                    print("Divide a los extremos infinitos\n")
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


