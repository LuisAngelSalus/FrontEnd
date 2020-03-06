function renderDashboardWorker(data) {
    let dataWorker = data;
    console.log("Datos", data); 
    let content = "";
    content += "<input id='workerIdhidden' type='hidden' value='" + dataWorker.WorkerId + "'>";
    content += "<input id='personIdhidden' type='hidden' value='" + dataWorker.PersonId + "'>";
    content += "<div class='card-body p-0'>";

    content += "<div class='card b-all shadow-none'>";

    content += "<div class='card-body'>";

    content += "<h3 class='card-title m-b-0'>Portal Salus Laboris</h3>";

    content += "</div>";
    content += "<div>";

    content += "<hr class='m-t-0'>";

    content += "</div>";
    content += "<div class='card-body col-12 col-md-8 '>";

    content += "    <p><b>Estimado Trabajador</b></p>";
    content += "    <p>Bienvenidos a la hoja de Actulización de Datos de Salus Laboris</p>";
    content += "    <p>Previo a su atención en nuestra clínica ocupacional requerimos que pueda confirmar o actualizar sus datos personales con la finalidad de mejorar su experiencia para el proceso de atención de su circuito de examenes programado.</p>";
    content += "    <p>Fecha de Programación:</p>";
    content += "    <p>Dirección de la clínica:</p>";

    content += "</div>";
    content += "<div>";

    content += "    <hr class='m-t-0'>";

    content += "</div>";
    content += "    <div class='card-body'>";

    content += "        <h4><i class='fa fa-user m-r-10 m-b-10'></i> Datos del trabajador</h4>";
    content += "        <div class='row'>";


    content += "        </div>";
    content += "        <div class='b-all m-t-20 p-20'>";

    content += "<div class='form-horizontal'>";
    content += "                <div class='form-body'>";
    content += "                    <h3 class='box-title'>Datos Obligatorios</h3>";
    content += "                    <hr class='m-t-0 m-b-40'>";
    content += "                        <div class='row'>";
    content += "                            <div class='col-md-6'>";
    content += "                                <div class='form-group row'>";
    content += "                                    <label class='control-label text-right col-md-3'>Primer Nombre</label>";
    content += "                                    <div class='col-md-9 '>";
    content += "                                        <input type='text' id='txtFirstName' class='form-control' value='" + dataWorker.FirstName + "' placeholder='Ingresar Primer Nombre'>";    
    content += "                                    </div>";
    content += "                                </div>";
    content += "                            </div>";
                
    content += "                <div class='col-md-6'>";
    content += "                                    <div class='form-group  row'>";
    content += "                                        <label class='control-label text-right col-md-3'>Primer Apellido</label>";
    content += "                                        <div class='col-md-9'>";
    content += "                                            <input type='text' id='txtFirstLastName' class='form-control' value='" + dataWorker.FirstLastName +"'  placeholder='Ingresar Primer Apellido'>";    
    content += "                        </div>";
    content += "                                        </div>";
    content += "                                    </div>";
                
    content += "            </div>";
                
    content += "            <div class='row'>";
    content += "                                    <div class='col-md-6'>";
    content += "                                        <div class='form-group  row'>";
    content += "                                            <label class='control-label text-right col-md-3'>Segundo Apellido</label>";
    content += "                                            <div class='col-md-9'>";
    content += "                                                <input type='text' id='txtSecondLastName' class='form-control ' value='" + dataWorker.SecondLastName +"' placeholder='Ingresar Segundo Apellido'>";    
    content += "                        </div>";
    content += "                                            </div>";
    content += "                                        </div>";
                
    content += "                <div class='col-md-6'>";
    content += "                                            <div class='form-group  row'>";
    content += "                                                <label class='control-label text-right col-md-3'>Nro. Documento</label>";
    content += "                                                <div class='col-md-9'>";
    content += "                                                    <input type='text' id='txtNroDocument' class='form-control ' value='" + dataWorker.NroDocument +"' placeholder='Ingresar Nro. Documento'>";    
    content += "                        </div>";
    content += "                                                </div>";
    content += "                                            </div>";
                
    content += "            </div>";
                
                
    content += "            <div class='row'>";
    content += "                <div class='col-md-6'>";
    content += "                    <div class='form-group   row'>";
    content += "                        <label  class='control-label text-right col-md-3'>Género</label>";
content += "                            <div class='col-md-9'>";
    content += "                                <select id='select-gender-Worker' class='form-control custom-select'>";
content += "                                        <option value='-1'>--Seleccionar--</option>";
content += "                                        <option value='1'>Masculino</option>";
content += "                                        <option value='2'>Femenino</option>";
content += "                                    </select>";
content += "                                <small class='form-control-feedback'> Dato obligatorio </small>";
content += "                            </div>";
    content += "                    </div>";
    content += "            </div>";
                
    content += "                <div class='col-md-6'>";
    content += "                                                <div class='form-group   row'>";
    content += "                                                    <label class='control-label text-right col-md-3'>Fecha Nacimiento</label>";
    content += "                                                    <div class='col-md-9'>";
    content += "                                                        <input id='dpt-DateOfBirth' type='date' class='form-control' placeholder='dd/mm/yyyy'>";
    content += "                        </div>";
    content += "                                                    </div>";
    content += "                                                </div>";
    
    content += "                        </div>";
                
    
    content += "                                                    <h3 class='box-title'>Datos Generales</h3>";
    content += "                                                    <hr class='m-t-0 m-b-40'>";

    content += "                                        <div class='row'>";
    content += "                                                <div class='col-md-6'>";
    content += "                                                    <div class='form-group row'>";
    content += "                                                        <label class='control-label text-right col-md-3'>Email</label>";
    content += "                                                        <div class='col-md-9'>";
    content += "                                                            <input type='text' id='txtEmail' class='form-control value='" + dataWorker.Email + "' placeholder='Ingresar Correo Electrónico'>";

    content += "                                                        </div>";
    content += "                                                    </div>";
    content += "                                                </div>";
    content += "                                            <div class='col-md-6'>";
    content += "                                                        <div class='form-group row'>";
    content += "                                                            <label class='control-label text-right col-md-3'>Celular</label>";
    content += "                                                            <div class='col-md-9'>";
    content += "                                                                <input type='text' id='txtMobileNumber' class='form-control' value='" + dataWorker.MobileNumber + "' placeholder='Ingresar Nro. de Celular'>";
    content += "                                                            </div>";
    content += "                                                        </div>";
    content += "                                                </div>";
    content += "                                        </div>";
    content += "                                                        <div class='row'>";
    content += "                                                            <div class='col-md-6'>";
    content += "                                                                <div class='form-group row'>";
    content += "                                                                    <label class='control-label text-right col-md-3'>Dirección domicilio</label>";
    content += "                                                                    <div class='col-md-9'>";
    content += "                                                                        <input type='text' id='txtHomeAddress' class='form-control' value='" + dataWorker.HomeAddress + "'placeholder='Ingresar Dirección'>";
    content += "                                                                    </div>";
    content += "                                                                </div>";
    content += "                                                            </div>";
    content += "                                                                <div class='col-md-6'>";
    content += "                                                                    <div class='form-group row'>";
    content += "                                                                        <label class='control-label text-right col-md-3'>Puesto de Trabajo</label>";
    content += "                                                                        <div class='col-md-9'>";
    content += "                                                                            <input type='text' id='txtCurrentPosition' class='form-control' value='" + dataWorker.CurrentPosition + "'placeholder='Ingresar Puesto Actual'>";
    content += "                        </div>";
    content += "                                                                        </div>";
    content += "                                                                    </div>";
    content += "                                                                </div>";
    content += "                                                            </div>";
    content += "                                                            <hr>";
    content += "                                                                <div class='form-actions'>";
    content += "                                                                    <div class='row'>";
    content += "                                                                        <div class='col-md-6'>";
    content += "                                                                            <div class='row'>";
    content += "                                                                                <div class='col-md-offset-3 col-md-9'>";
    content += "                                                                                    <button id='btnUpdateDataWorker' class='btn btn-success'>Actualizar Datos</button>";
    content += "                                                                                </div>";
    content += "                                                                            </div>";
    content += "                                                                        </div>";
    content += "                                                                        <div class='col-md-6'> </div>";
    content += "                                                                    </div>";
    content += "                                                                </div>";
    content += "    </div>";

    content += "                                                        </div>";

    content += "</div>";
    content += "                                                    <div>";

    content += "                                                                <hr class='m-t-0'>";
    content += "                                                            <div class='card-body'>";

    content += "                                                                <h4><i class='fa fa-eye m-r-10 m-b-10'></i> Tener en cuenta lo siguiente</h4>";
    content += "                                                                <div class='p-l-10'>";

    content += "                                                                    <p><strong>1. </strong>Traer DNI con vigencia activa</p>";
    content += "                                                                                <p><strong>2. </strong>Haber descansaso mínimo 10 horas</p>";
    content += "                                                                    <p><strong>3. </strong>No ingerir alimentos durante las últimas 10 horas</p>";
    content += "                                                                    <p><strong>4. </strong>Llegar 15 min. antes de la cita</p>";
    content += "                                                                    <p><strong>5. </strong>Traer lentes en caso los utilice</p>";
    content += "                                                                    <p><strong>6. </strong>Reposo auditivo durante las últimas 12 horas</p>";
    content += "                                                                </div>";

    content += "                                                            </div>";

    content += "</div>";


    content += "                                                    </div>";
    content += "                                                </div>";

    return content;
}