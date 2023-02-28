
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Alumno } from '../models/alumno';
import { Genero, GeneroArray } from '../models/genero';

@Injectable({
  providedIn: 'root'
})
export class AlumnoService {
  myAppUrl : string = 'https://localhost:7260/';
  urlAlumno : string = 'api/Alumno/';
  urlGenero : string = 'api/Genero/';
  list : Alumno[] = []
  private actualizarFormulario = new BehaviorSubject<Alumno>({} as any);

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
  }

  getGenero() : Observable<GeneroArray> {
    return this.http.get<GeneroArray>(this.myAppUrl + this.urlGenero);
  }

  guardarAlumno(alumno : Alumno) : Observable<Alumno>{    
    return this.http.post<Alumno>(this.myAppUrl + this.urlAlumno, alumno);
  }

  getAlumnos(){
    this.http.get(this.myAppUrl + this.urlAlumno).toPromise()
                  .then(data =>{                    
                    this.list = data as Alumno[];
                  })
  }

  deleteAlumno(id : number) : Observable<Alumno>{
    return this.http.delete<Alumno>(this.myAppUrl + this.urlAlumno + id);
  }

  actualizarAlumno(alumno : Alumno){
    this.actualizarFormulario.next(alumno);
  }

  updateAlumno(id:number, alumno:Alumno):Observable<Alumno>{
    return this.http.put<Alumno>(this.myAppUrl + this.urlAlumno + id, alumno)
  }

  obtenerAlumno$() : Observable<Alumno>{
    return this.actualizarFormulario.asObservable();
  }
}
