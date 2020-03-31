function renderDashboardWorker(data) {
    let dataWorker = data;

    let content = "";

    content += "<div class='content-alert'>";
    content += "</div>";
    content += "<input id='workerIdhidden' type='hidden' value='" + dataWorker.WorkerId + "'>";
    content += "<input id='personIdhidden' type='hidden' value='" + dataWorker.PersonId + "'>";
    content += "<div class='card-body p-0'>";

    content += "<div class='card b-all shadow-none'>";

    content += "<div class='card-body'>";

    content += "    <h3 class='card-title m-b-0'>Portal Salus Laboris</h3>";

    content += "    </div>";
    content += "    <div>";

    content += "        <hr class='m-t-0'>";

    content += "    </div>";
    content += "    <div class='card-body col-12 col-md-8 '>";

    content += "        <p><b>Estimado Trabajador</b></p>";
    content += "        <p>Bienvenidos a la hoja de Actulización de Datos de Salus Laboris</p>";
    content += "        <p>Previo a su atención en nuestra clínica ocupacional requerimos que pueda confirmar o actualizar sus datos personales con la finalidad de mejorar su experiencia para el proceso de atención de su circuito de examenes programado.</p>";
    content += "        <p>Fecha de Programación:</p>";
    content += "        <p>Dirección de la clínica:</p>";

    content += "    </div>";
    content += "    <div>";

    content += "        <hr class='m-t-0'>";

    content += "    </div>";
    content += "    <div class='card-body'>";

    content += "        <h4><i class='fa fa-user m-r-10 m-b-10'></i> Datos del trabajador</h4>";
    content += "        <div class='row'>";

    content += "        </div>";
    content += "        <div class='b-all m-t-20 p-20'>";

    content += "            <div class='form-horizontal'>";
    content += "                <div class='form-body'>";
    content += "                    <h3 class='box-title'>Datos Obligatorios</h3>";
    content += "                    <hr class='m-t-0 m-b-40'>";
    content += "                    <div class='row'>"; //inicio
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group row'>";
    content += "                                <label class='control-label text-right col-md-3'>Primer Nombre</label>";
    content += "                                <div class='col-md-9 '>";
    content += "                                    <input type='text' id='txtFirstName' class='form-control' value='" + dataWorker.FirstName + "' placeholder='Ingresar Primer Nombre' required>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";

    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group  row'>";
    content += "                                <label class='control-label text-right col-md-3'>Primer Apellido</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input type='text' id='txtFirstLastName' class='form-control' value='" + dataWorker.FirstLastName + "'  placeholder='Ingresar Primer Apellido' required>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                    </div>";//Fin

    content += "                    <div class='row'>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group  row'>";
    content += "                                <label class='control-label text-right col-md-3'>Segundo Apellido</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input type='text' id='txtSecondLastName' class='form-control ' value='" + dataWorker.SecondLastName + "' placeholder='Ingresar Segundo Apellido' required>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";

    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group  row'>";
    content += "                                <label class='control-label text-right col-md-3'>Nro. Documento</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input type='text' id='txtNroDocument' class='form-control ' value='" + dataWorker.NroDocument + "' placeholder='Ingresar Nro. Documento' required>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                    </div>";


    content += "                    <div class='row'>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group   row'>";
    content += "                                <label  class='control-label text-right col-md-3'>Género</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <select id='select-gender-Worker' class='form-control custom-select'>";
    content += "                                        <option value='-1'>--Seleccionar--</option>";
    content += "                                        <option value='1'>Masculino</option>";
    content += "                                        <option value='2'>Femenino</option>";
    content += "                                    </select>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";

    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group row'>";
    content += "                                <label class='control-label text-right col-md-3'>Fecha Nacimiento</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input id='dpt-DateOfBirth' class='form-control' required>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";

    content += "                    </div>";

    content += "                    <div class='row'>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='card-body m-0 p-0' style='text-align: center'>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                    </div>";


    content += "                    <div class='row'>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group row'>";
    content += "                                <label class='control-label text-right col-md-3'>Foto</label>";
    content += "                                <div class='col-md-9' style='text-align:center'>";
    content += "                                    <img id='imgFoto' src='~/Content/LogosCompany/'" + dataWorker.NroDocument + "' alt='Foto paciente' class='img-fluid img-thumbnail rounded mx-auto d-block'/>";
    content += "                                        <div style='text-align:center'>";
    content += "                                            <button type='button' onclick='changeFoto()' class='btn waves-effect waves-light btn-xs btn-info'>Cambiar</button>";
    content += "                                            <button type='button' onclick='removeFoto()' class='btn waves-effect waves-light btn-xs btn-danger'>Eliminar</button>";
    content += "                                        </div>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                    </div>";


    content += "                    <h3 class='box-title'>Datos Generales</h3>";
    content += "                    <hr class='m-t-0 m-b-40'>";

    content += "                    <div class='row'>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group row'>";
    content += "                                <label class='control-label text-right col-md-3'>Email</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input type='text' id='txtEmail' class='form-control' value='" + dataWorker.Email + "' placeholder='Ingresar Correo Electrónico' required>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";

    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group row'>";
    content += "                                <label class='control-label text-right col-md-3'>Celular</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input type='text' id='txtMobileNumber' class='form-control' value='" + dataWorker.MobileNumber + "' placeholder='Ingresar Nro. de Celular' required>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                    </div>";

    content += "                    <div class='row'>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group row'>";
    content += "                                <label class='control-label text-right col-md-3'>Dirección domicilio</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input type='text' id='txtHomeAddress' class='form-control' value='" + dataWorker.HomeAddress + "'placeholder='Ingresar Dirección'>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='form-group row'>";
    content += "                                <label class='control-label text-right col-md-3'>Puesto de Trabajo</label>";
    content += "                                <div class='col-md-9'>";
    content += "                                    <input type='text' id='txtCurrentPosition' class='form-control' value='" + dataWorker.CurrentPosition + "'placeholder='Ingresar Puesto Actual'>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                    </div>";
    content += "                </div>";
    content += "                <hr>";
    content += "                <div class='form-actions'>";
    content += "                    <div class='row'>";
    content += "                        <div class='col-md-6'>";
    content += "                            <div class='row'>";
    content += "                                <div class='col-md-offset-3 col-md-9'>";
    content += "                                    <button id='btnUpdateDataWorker' class='btn btn-success'>Actualizar Datos</button>";
    content += "                                </div>";
    content += "                            </div>";
    content += "                        </div>";
    content += "                        <div class='col-md-6'> </div>";
    content += "                    </div>";
    content += "                </div>";
    content += "            </div>";
    content += "        </div>";
    content += "    </div>";

    content += "    <div>";
    content += "        <hr class='m-t-0'>";
    content += "        <div class='card-body'>";
    content += "            <h4><i class='fa fa-eye m-r-10 m-b-10'></i> Tener en cuenta lo siguiente</h4>";
    content += "            <div class='p-l-10'>";
    content += "                <p><strong>1. </strong>Traer DNI con vigencia activa</p>";
    content += "                <p><strong>2. </strong>Haber descansaso mínimo 10 horas</p>";
    content += "                <p><strong>3. </strong>No ingerir alimentos durante las últimas 10 horas</p>";
    content += "                <p><strong>4. </strong>Llegar 15 min. antes de la cita</p>";
    content += "                <p><strong>5. </strong>Traer lentes en caso los utilice</p>";
    content += "                <p><strong>6. </strong>Reposo auditivo durante las últimas 12 horas</p>";
    content += "            </div>";
    content += "        </div>";
    content += "    </div>";

    content += "</div>";
    content += "</div>";

    content += "<div class='modal fade' id='modalUploadFoto' tabindex='-1' role='dialog' aria-labelledby='modalUploadLogoLabel'>";
    content += "    <div class='modal-dialog modal-md' role='document'>";
    content += "        <div class='modal-content'>";
    content += "            <div class='modal-header'>";
    content += "                <h4 class='modal-title' id='modalUploadLogoLabel'>Seleccionar Imagen</h4>";
    content += "                <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>";
    content += "            </div>";
    content += "            <div class='modal-body' style='font-size:10px;'>";
    content += "                <input type='file' id='input-file-now-foto' class='dropify' data-allowed-file-extensions='png' data-max-file-size='200K'/>";
    content += "            </div>";
    content += "            <div class='modal-footer'>";
    content += "                <button type='button' onclick='AcceptFoto()' class='btn btn-info' data-dismiss='modal'>Aceptar</button>";
    content += "            </div>";
    content += "        </div>";
    content += "    </div>";
    content += "</div>";


    return content;
}