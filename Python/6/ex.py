
nombreA=''
while True:
    nombreA= input('Ingrese el archivo asis.csv(Enter para salir): ')
    if nombreA=='': 
        print("**Programa finalizado**") 
        break
    try:
        if len(nombreA) < 1 : nombreA='asis.csv',
        archivo= open(nombreA, encoding="utf-8")
        archivoU=open('universitarios.csv','w')
        archivoC=open('certificados.csv','w')
        con=0
        print("Nombre-Apellido-Universitario-DeseaCertificado")
        for linea in archivo:
            con+=1
            if con>1:
                linea=linea.rstrip()
                wds=linea.split(';')
                for opcion in wds: 
                    opcion=wds[0]+'-'+wds[1]+'-'+wds[2]+'-'+wds[3]
                print(" ",opcion)
                nom_ape=wds[0]+wds[1]
                uni=wds[2]
                cert=wds[3]

                if uni=='SI':
                    archivoU.write(nom_ape+": es universitario \n")
                else:
                    continue
                    
                if cert=='SI':
                    archivoC.write(nom_ape+": requiere de certificado\n")
                else:
                    continue
                    

        print("\nEntonces, las personas universitarias son:")
        archivoU=open('universitarios.csv','r')
        item=0
        for linea in archivoU:
            item+=1
            linea=linea.rstrip()
            wds=linea.split(':')
            for opcion in wds:
                opcion=wds[0]
            print(item,"-",opcion)
        if item<53:
            print("En realidad deben ser 53")
        else:
            print("Sí, el total es 53")

        print("\nY las personas con certificados:")
        archivoC=open('certificados.csv','r')
        item=0
        for linea in archivoC:
            item+=1
            linea=linea.rstrip()
            wds=linea.split(':')
            for opcion in wds: 
                opcion=wds[0]
            print(item,"-",opcion)
        if item<66:
            print("En realidad deben ser 66, aunque universitarios con certificados sí son 51")
        else:
            print("Sí, el total es 66")

    except:
        print(nombreA," No corresponde. Ingrese otra vez")
        continue