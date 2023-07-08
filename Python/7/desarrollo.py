from psycopg2 import Error

class alumos():
    def init (self,archivo):
        self.archivo=archivo
    
    def listar(self):
        print("\nListado de Alumnos\n")
        arch=self.archivo
        ai=arch
        contenido=open(ai,'r',encoding="utf-8")
        for linea in contenido:
            linea=linea.rstrip()
        print(" ",linea)
    
    def buscar(self,ci):
        datos=''
        archAl=self.archivo
        archAl=open (archAl,'r',encoding="utf-8")
        con=0
        for linea in archAl:
            con+=1
            result=''
            if con>1:
                linea=linea.rstrip()
                wds=linea.split(';')
                cdi=wds[0]
                if int(cdi)==int(ci):
                    datos=linea
                    break
        return(datos)

nombreA=''
while True:
    nombreA= input('Ingrese el archivo alus.csv(Enter para salir): ')
    if nombreA=='': 
        print("**Programa finalizado**") 
        break
    try:
        if len(nombreA) < 1:
            nombreA=alumos('alus.csv')
        for linea in nombreA:
            nombreA.listar()
            print("\n")

            dni=input ("Ingrese CI (99 para salir: )")
            if int(dni)==99:
                print("\nOperación Cancelada\n")
                break
            else:
                file="ficha"+str(dni)+".csv"
                try:
                    arch=open(file,'r',encoding="utf-8")
                except:
                    arch=''

            if arch:
                for linea in arch:
                    linea=linea.rstrip()
                    print(linea)  
                continue
            else:
                new=nombreA.buscar(dni)
                if new:
                    print("\n",new,"\nIngreso de datos adicionales para la ficha:\n")
                    edad=input("Edad: ")
                    ciudad=input("Ciudad: ")
                    dato= new+";"+str(edad)+";"+ciudad+"\n"
                    fichAl=open(file,'w')
                    fichAl.write()
                else:
                    continue
    except (Exception, Error) as error:
        print(nombreA," No corresponde. Ingrese otra vez. ",error)
        continue