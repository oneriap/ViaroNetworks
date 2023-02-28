import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AlumnoService } from 'src/app/services/alumno.service';
import { Alumno } from 'src/app/models/alumno';

@Component({
  selector: 'app-alumno-list',
  templateUrl: './alumno-list.component.html',
  styleUrls: ['./alumno-list.component.css']
})
export class AlumnoListComponent implements OnInit {

  constructor(public alumnoService : AlumnoService, public toastr : ToastrService) { }

  ngOnInit(): void {
    this.alumnoService.getAlumnos();
  }

  deleteAlumno(id : number){
    if(confirm("¿Desea eliminar este registro?")){
      this.alumnoService.deleteAlumno(id).subscribe(
        data => {
            this.toastr.warning('Se eliminó el alumno','Alumno eliminado');
            this.alumnoService.getAlumnos();
          }
      )
    }
  }

  editar(alumno : Alumno){
    this.alumnoService.actualizarAlumno(alumno)
  }
}
