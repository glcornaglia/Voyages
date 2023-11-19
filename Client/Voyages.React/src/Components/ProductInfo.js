
import {FormGroupInput} from "./Elements"

export default function ProductInfo({ productData }) {

    if (productData)
        return (
            <>
                <div className="container card">
                    <div className="row">
                        <div className="col-md-12">
                            <div className="well well-sm">
                                <div className="form-horizontal">
                                    <legend className="header">Information Produit</legend>

                                    <div className="row">

                                        <div className="col-md-6">
                                            <FormGroupInput text="Type" value={productData.type} name="type" icon="building"/>
                                        </div>

                                        <div className="col-md-6">
                                            <FormGroupInput text="Produit" value={productData.name} name="name" icon="vcard-o"/>
                                        </div>

                                    </div>

                                    <div className="row">

                                        <div className="col-md-8">
                                            <FormGroupInput text="Adresse" value={productData.address} name="address" icon="home"/>
                                        </div>

                                        <div className="col-md-4">
                                            <FormGroupInput text="Téléphone" value={productData.telephone} name="telephone" icon="phone-square"/>
                                        </div>

                                    </div>

                                    <div className="row">

                                        <div className="col-md-6">
                                            <div className="form-group">
                                                <span className="col-md-12 col-md-offset-2 text-center"><i className="fa fa-info bigicon"></i></span>
                                                <label className="control-label">Description</label>
                                                <textarea id="description" value={productData.description} readOnly name="description" type="text" className="form-control" rows="7" />
                                            </div>
                                        </div>

                                        <div className="col-md-6">
                                            <div className="form-group">
                                                <span className="col-md-12 col-md-offset-2 text-center"><i className="fa fa-camera-retro bigicon"></i></span>
                                                <label className="control-label">Photo</label>
                                                <img id="photolink" src={productData.photoLink} alt={productData.name} readOnly name="photolink" className="form-control" />
                                            </div>
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