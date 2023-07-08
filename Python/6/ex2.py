def text_palindromo(opcion):
    saludo=("Hola")
    return (saludo)

def promedio_letras(text,opcion):
    total_letras=len(text)
    cantidad_palabras=len(text.split())
    prome_let=total_letras/cantidad_palabras
    return (total_letras,cantidad_palabras,prome_let)

while True:
    nombreA= input('Ingrese el archivo menu.txt(Enter para salir): ')
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
                    saludo=text_palindromo(opcion)
                    print("El saludo es ", saludo)
                elif opcion==2:
                    texto=input("Ingrese el texto que se te ocurra: ")
                    print("\nEl promedio de letras pero incluyendo sólo espacios entre ellas en \n[", texto,"]")
                    text=texto.strip()
                    resultado=promedio_letras(text,opcion)
                    print("es (total de letras,cantidad de palabras y promedio de letras ) ",resultado,"\n")
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