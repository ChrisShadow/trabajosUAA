from psycopg2 import Error

class alumno():
    def _init_(self):
        from psycopg2 import connect
        user='postgres'
        password='123ABC459'
        host='127.0.0.1'
        port=5432
        database='uaa2022'
        values='dname=%s dhost=%s dport=%s duse=%s dpass=%s' % (database,host,port,user,password)
        self.connec=connect(values)
        self.cursor=self.connec.cursor()
        
    def consultar(self,select_query):
        self.cursor.execute(select_query)
        registros=self.cursor.fetchall()
        return registros

    def consultarParms(self,select_query,par):
        self.cursor.execute(select_query,par)
        registros=self.cursor.fetchall()
        return registros

    def reporteAluApe(self):
        sql='select documento,apellido,nombre from alumnos order by apellido,nombre'
        datos=a.consultar(sql)
        if datos:
            print("\nDatos de alumnos ordenado por apellidos y nombres\n    Documento         Apellido                Nombre")
            item=0
            for d in datos:
                item+=1
                print(item,"-",d[0],"        ",d[1],"                ",d[2])
        return

    def reporteAluDocu(self):
        sql='select documento,apellido,nombre from alumnos order by documento'
        datos=a.consultar(sql)
        if datos:
            print("\nDatos de alumnos ordenado por Nro de Ci\n      CI          Nombre                      Apellido")
            item=0
            for d in datos:
                item+=1
                print(item,"-",d[0],"        ",d[2],"                ",d[1])
        return
    
    def reporteNotasMate(self):
        sql='select documento,apellido,nombre from alumnos order by documento'
        datos=a.consultar(sql)
        if datos:
            print("\nReporte de Notas Matemáticas\n     CI              Apellidos                       Nombres                                     Nota P1     Nota P2     NotaP3      Promedio")
            item=0
            for d in datos:
                item+=1
                doc=d[0]
                select_query="""select nota from notas where documento=%s and materia='Matemáticas' """
                parN=(doc,)
                notas=a.consultarParms(select_query,parN)
                listN=[]
                for n in notas:
                    listN.append(n)
                    #print(listN)
                prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
                print(item,"-",d[0],"        ",d[1],"                ",d[2],"                       ",listN[0],"        ",listN[1],"        ",listN[2],"        ",int(prom))
        return
                
    def reporteNotasPyt(self):
        sql='select documento,apellido,nombre from alumnos order by documento'
        datos=a.consultar(sql)
        if datos:
            print("\nReporte de Notas Python\n     CI              Apellidos                       Nombres                                     Nota P1     Nota P2     NotaP3      Promedio")
            item=0
            for d in datos:
                item+=1
                doc=d[0]
                select_query="""select nota from notas where documento=%s and materia='Python' """
                parN=(doc,)
                notas=a.consultarParms(select_query,parN)
                listN=[]
                for n in notas:
                    listN.append(n)
                    #print(listN)
                prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
                print(item,"-",d[0],"        ",d[1],"                ",d[2],"                       ",listN[0],"        ",listN[1],"        ",listN[2],"        ",int(prom))
        return
    
    def csvAluApe(self):
        sql="""select documento,apellido,nombre from alumnos order by apellido,nombre """
        datos=a.consultar(sql)
        if datos:
            listaAlu=open('listaAlumnosApellidos.csv','w')
            linea="Documento;Apellido;Nombre\n"
            listaAlu.write(linea)
            for d in datos:
                linea="%s;%s;%s\n" % (d[0],d[1],d[2])
                listaAlu.write(linea)
            listaAlu.close()
            print("\nLista de alumnos ordenados por Apellido y Nombre guardado con éxito")

    def csvAluDoc(self):
        sql="""select documento,apellido,nombre from alumnos order by documento """
        datos=a.consultar(sql)
        if datos:
            listaDoc=open('listaAlumnosDocumento.csv','w')
            linea="Documento;Nombre;Apellido\n"
            listaDoc.write(linea)
            for d in datos:
                linea="%s;%s;%s\n" % (d[0],d[2],d[1])
                listaDoc.write(linea)
            listaDoc.close()
            print("\nLista de alumnos ordenados por Documento guardado con éxito")

    def csvNotasMate(self):
        sql="""select documento,apellido,nombre from alumnos order by documento """
        datos=a.consultar(sql)
        if datos:
            notasM=open('notasMatematicasPromedio.csv','w')
            linea=("Documento;Apellido;Nombre;P1;P2;P3;Promedio\n")
            notasM.write(linea)
            for d in datos:
                doc=d[0]
                select_query="""select nota from notas where documento=%s and materia='Matemáticas' """
                parN=(doc,)
                notas=a.consultarParms(select_query,parN)
                listN=[]
                for n in notas:
                    listN.append(n)
                    #print(listN)
                prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
                linea='%s;%s;%s;%s;%s;%s;%s\n' % (d[0],d[1],d[2],listN[0],listN[1],listN[2],prom)
                notasM.write(linea)
            notasM.close()
            print("\nLista de alumnos con sus notas y promedio en matemáticas guardado con éxito")

    def csvNotasPy(self):
        sql="""select documento,apellido,nombre from alumnos order by documento """
        datos=a.consultar(sql)
        if datos:
            notasP=open('notasPythonPromedio.csv','w')
            linea=("Documento;Apellido;Nombre;P1;P2;P3;Promedio\n")
            notasP.write(linea)
            for d in datos:
                doc=d[0]
                select_query="""select nota from notas where documento=%s and materia='Python' """
                parN=(doc,)
                notas=a.consultarParms(select_query,parN)
                listN=[]
                for n in notas:
                    listN.append(n)
                    #print(listN)
                prom=sum(listN[0]+listN[1]+listN[2])/len(listN) 
                linea='%s;%s;%s;%s;%s;%s;%s\n' % (d[0],d[1],d[2],listN[0],listN[1],listN[2],prom)
                notasP.write(linea)
            notasP.close()
            print("\nLista de alumnos con sus notas y promedio en Python guardado con éxito")

try:
    a=alumno()
    while True:
        nombreM= input('Ingrese el archivo reportes.txt(Enter para salir): ')
        if nombreM=='': 
            print("**redirigiendo**") 
            break
        try:
            if len(nombreM) < 1 : nombreM='reportes.txt',
            while not False:
                archivo= open(nombreM, encoding="utf-8")
                menu=[]
                print("\n--MENÚ DE OPERACIONES--")
                for linea in archivo:
                    linea=linea.rstrip()
                    wds=linea.split(':')
                    for opcion in wds: 
                        opcion=wds[0]+'-'+wds[1]
                        menu.append(opcion)   
                    print(" ",opcion)
                dato=input("\nIngrese una opción a ejecutar:")
                try:
                    opcion=int(dato)
                    if opcion==1:
                        a.reporteAluApe()
                    elif opcion==2:
                        a.reporteAluDocu() 
                    elif opcion==3:
                        a.reporteNotasMate()
                    elif opcion==4:
                        a.reporteNotasPyt()
                    elif opcion==5:
                        a.csvAluApe()
                    elif opcion==6:
                        a.csvAluDoc()
                    elif opcion==7:
                        a.csvNotasMate()
                    elif opcion==8:
                        a.csvNotasPy()
                    elif opcion==99:
                        print("--Saliendo del menú--\n")
                        break
                    else:
                        print(opcion," no corresponde.Intente de vuelta\n")
                        continue
                except (Exception, Error) as error:
                    print("\nDebe ser solo número. Intente de vuelta\n\n",error)
                    continue
        except (Exception, Error) as error:
            print(nombreM,"No corresponde. Ingrese otra vez. ",error)
            continue
except (Exception, Error) as error:
    print("Error mientras se intentó conectar a PostgreSQL:", error)
