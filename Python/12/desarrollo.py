from psycopg2 import Error

class alumno():
    def _init_(self):
        import psycopg2
        from psycopg2 import connect
        self.connection= psycopg2.connect(user='postgres',
        password='123ABC459',
        host='127.0.0.1',
        port="5432",
        database='uaa2022') 
        self.cursor=self.connection.cursor()
        
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
        
    
a=alumno()
a.reporteAluApe()        
""" try:
      
except (Exception, Error) as error:
    print("Error mientras se intentó conectar a PostgreSQL:", error) """
    

