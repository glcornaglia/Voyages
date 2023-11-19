
import {FormGroupInput} from "./Elements"

export default function ClientInfo({ clientData }) {

  if (clientData)
    return (
      <>
        <div className="container card">
          <div className="row">
            <div className="col-md-12">
              <div className="well well-sm">
                <div className="form-horizontal">
                  <legend className="header">Information Client</legend>

                  <div className="row">

                    <div className="col-md-6">
                      <FormGroupInput text="Prénom" value={clientData.name} name="name" icon="user"/>
                    </div>

                    <div className="col-md-6">
                      <FormGroupInput text="Nom" value={clientData.lastName} name="lastname" icon="user"/>
                    </div>

                  </div>

                  <div className="row">

                    <div className="col-md-12">
                      <FormGroupInput text="Adresse" value={clientData.address} name="address" icon="home"/>
                    </div>

                  </div>

                  <div className="row">

                    <div className="col-md-4">
                      <FormGroupInput text="Téléphone" value={clientData.telephone} name="telephone" icon="phone"/>
                    </div>

                    <div className="col-md-4">
                      <FormGroupInput text="E-mail" value={clientData.email} name="email" icon="envelope-o"/>
                    </div>

                    <div className="col-md-4">
                      <FormGroupInput text="Date de naissance" value={clientData.birthDate} name="birthDate" icon="birthday-cake"/>
                    </div>

                  </div>

                </div>
              </div>
            </div>
          </div>
        </div>
      </>

    )
}