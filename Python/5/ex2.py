nombreA=''
while True:
    nombreA= input('Ingrese el archivo(Enter para salir): ')
    if nombreA=='': 
        print("**Programa finalizado**") 
        break
    try:
        if len(nombreA) < 1 : nombreA='menu.txt',
        while not False:
            archivo= open(nombreA, encoding="utf-8")
            menu=[]
            print("--MENÚ DE OPERACIONES--")
            for linea in archivo:
                linea=linea.rstrip()
                wds=linea.split(':')
                for opcion in wds: 
                    opcion=wds[0]+'-'+wds[1]
                    menu.append(opcion)   
                print(" ",opcion)


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
                            print(number, " es par\n")
                        else:
                            print(number, " es impar\n")
                    except:
                        print("Debe ser solo número. Intente de vuelta\n\n")
                    continue
                elif opcion==99:
                    print("--Saliendo del programa--\n")
                    break
                else:
                    print("No corresponde.Intente de vuelta\n")
                    continue
            
            except:
                print("Debe ser solo número. Intente de vuelta\n\n")
                continue
 
    except:
        print(nombreA," No corresponde. Ingrese otra vez")
        continue