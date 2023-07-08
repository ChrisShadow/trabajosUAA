nombreA=''
while True:
    nombreA= input('Ingrese el archivo inscriptos.csv(Enter para salir): ')
    if nombreA=='': 
        print("**Programa finalizado**") 
        break
    try:
        if len(nombreA) < 1 : nombreA='inscriptos.csv',
        archivo= open(nombreA, encoding="utf-8")
        archivoCo=open('aCobrar.csv','w')
        archivoCe=open('aCertificar.csv','w')
        con=0
        print("Nombre|Apellido|DeseaCertificado")
        for linea in archivo:
            con+=1
            if con>1:
                linea=linea.rstrip()
                wds=linea.split('|')
                for opcion in wds: 
                    opcion=wds[0]+'-'+wds[1]+'-'+wds[2]
                print(" ",opcion)
                nom=wds[0]
                ape=wds[1]
                cert=wds[2]

                if cert=='SI':
                    archivoCo.write(nom+";"+ape+";abona 120.000 \n")
                    archivoCe.write(ape+","+nom+"\n")
                else:
                    archivoCo.write(nom+";"+ape+";abona 100.000 \n")
                    continue
                    
        print("\nEntonces, las personas inscriptas son:")
        archivoCo=open('aCobrar.csv','r')
        item=0
        for linea in archivoCo:
            item+=1
            linea=linea.rstrip()
            wds=linea.split(';')
            for opcion in wds:
                opcion=wds[0]+';'+wds[1]+';'+wds[2]
            print(item,"-",opcion)

        print("\nY las personas con certificados:")
        archivoCe=open('aCertificar.csv','r')
        item=0
        for linea in archivoCe:
            item+=1
            linea=linea.rstrip()
            wds=linea.split(',')
            for opcion in wds: 
                opcion=wds[0]+','+wds[1]
            print(item,"-",opcion)

        print("\n")
    except:
        print(nombreA," No corresponde. Ingrese otra vez")
        continue