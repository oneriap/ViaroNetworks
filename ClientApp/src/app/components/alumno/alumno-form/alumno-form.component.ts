import { getLocaleDateFormat } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs/internal/Subscription';
import { Alumno } from 'src/app/models/alumno';
import { Genero, GeneroArray } from 'src/app/models/genero';
import { AlumnoService } from 'src/app/services/alumno.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-alumno-form',
  templateUrl: './alumno-form.component.html',
  styleUrls: ['./alumno-form.component.css']
})
export class AlumnoFormComponent implements OnInit, OnDestroy {
  
  alumno : Alumno = new Alumno();
  subscription : Subscription = new Subscription();
  form : FormGroup;
  generos: Genero[] = [{id : 1, descripcion:'Mujer'},
                        {id : 2, descripcion:'Hombre'},
                        {id : 3, descripcion:'No definido'}]


  constructor(private formBuilder : FormBuilder, 
                private alumnoService : AlumnoService,
                private toastr : ToastrService) {
    this.form = this.formBuilder.group({
      idAlumno: 0,
      nombre : ['', [Validators.required]],
      apellidos : ['', [Validators.required]],
      genero : [null, [Validators.required]],
      fechaNacimiento: ['', [Validators.required]]      
    });
    
    
    
  }

  ngOnInit(): void {
    this.subscription = this.alumnoService.obtenerAlumno$()
    .subscribe(data => {
      this.alumno = data;
      this.form.patchValue({
        nombre : this.alumno.nombre,
        apellidos : this.alumno.apellidos,
        idgenero : this.alumno.idGenero,
        genero : {
                    id : this.alumno.genero?.id,
                    descripcion : this.alumno.genero?.descripcion
                  },
        fechaNacimiento : new DatePipe("en-US")
                          .transform(this.alumno.fechaNacimiento,'yyy-MM-dd')
      })
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  guardar(){
    if(this.alumno.id === 0 || this.alumno.id === undefined){
      this.agregar();
    }else{
      this.editar();
    }
    
  }

  agregar(){
    const alumno : Alumno = {
      id : 0,
      nombre : this.form.get('nombre')?.value,
      apellidos : this.form.get('apellidos')?.value,
      idGenero : this.form.get('genero')?.value.id,
      fechaNacimiento : this.form.get('fechaNacimiento')?.value
    }

    this.alumnoService.guardarAlumno(alumno).subscribe(data => {
      this.toastr.success('El alumno fue agregado', 'Registro guardado');
      this.alumnoService.getAlumnos();
      this.form.reset();
    });
  }

  editar(){
    const alumno : Alumno = {
      id : this.alumno.id,
      nombre : this.form.get('nombre')?.value,
      apellidos : this.form.get('apellidos')?.value,
      idGenero : this.form.get('genero')?.value.id,
      fechaNacimiento : this.form.get('fechaNacimiento')?.value
    };

    

    this.alumnoService.updateAlumno(alumno.id, alumno).subscribe(data =>{
      this.toastr.info('El alumno fue actualizado', 'Registro actualizado');
      this.alumnoService.getAlumnos();
      this.form.reset();
      this.alumno = new Alumno();
    })
  }
}
