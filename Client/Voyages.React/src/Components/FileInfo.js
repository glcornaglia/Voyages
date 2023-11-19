
import { FormGroupInput } from "./Elements"

export default function FileInfo({ fileData }) {

    if (fileData)
        return (
            <>
                <div className="container card">
                    <div className="row">
                        <div className="col-md-12">
                            <div className="well well-sm">
                                <div className="form-horizontal">
                                    <legend className="header">Information Dossier</legend>

                                    <div className="row">

                                        <div className="col-md-4">
                                            <FormGroupInput text="Type" value={fileData.type} name="type" icon="file" />
                                        </div>

                                        <div className="col-md-4">
                                            <FormGroupInput text="Lieu" value={fileData.place} name="place" icon="globe" />
                                        </div>

                                        <div className="col-md-4">
                                            <FormGroupInput text="Prix" value={fileData.price} name="price" icon="money" />
                                        </div>

                                    </div>

                                    <div className="row">

                                        <div className="col-md-4">
                                            <FormGroupInput text="Date d’arrivée" value={fileData.arrivalDate} name="arrivalDate" icon="calendar" />
                                        </div>

                                        <div className="col-md-4">
                                            <FormGroupInput text="Durée du séjour" value={fileData.duration} name="duration" icon="hourglass" />
                                        </div>

                                        <div className="col-md-4">
                                            <FormGroupInput text="Numéro de vol" value={fileData.flightNumber} name="flightNumber" icon="plane" />
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