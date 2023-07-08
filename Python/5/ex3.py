nombreA=''
while True:
    nombreA= input('Ingrese el archivo(Enter para salir): ')
    if nombreA=='': 
        print("**Programa finalizado**") 
        break
    try:
        if len(nombreA) < 1 : nombreA='notas.txt',
        archivo= open(nombreA, encoding="utf-8")
        con=0
        print("Alumnos-Calificación")
        for linea in archivo:
            con+=1
            if con>1:
                linea=linea.rstrip()
                wds=linea.split(':')
                for opcion in wds: 
                    opcion=wds[0]+'-'+wds[1]
                nota=int(wds[1])
                if nota<2:
                    print(wds[0], " se aplazó con ", nota)
                else:
                    print(wds[0]," salvó con ", nota)
           
    except:
        print(nombreA," No corresponde. Ingrese otra vez")
        continue