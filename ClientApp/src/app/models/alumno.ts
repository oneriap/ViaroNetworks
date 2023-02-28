import { Genero } from "./genero";

export class Alumno {
    id : number = 0;
    nombre : string = '';   
    apellidos? : string;
    idGenero? : number;
    fechaNacimiento? : Date;
    genero? : Genero;
}