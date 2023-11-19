
  export function Message({message}) {
    return (
        <div className="container card">
        <label className="control-label">{message}</label>
      </div>
    );
  }

  export function FormGroupInput({text, value, name, icon}) {
    return (
        <div className="form-group">
          <span className="col-md-12 col-md-offset-2 text-center"><i className={"fa fa-" + icon + " bigicon"}></i></span>
          <label className="control-label">{text}</label>
          <input id={name} value={value} readOnly name={name} type="text" className="form-control" />
        </div>
    );
  }

  export default function Elements3({message}) {
    return (
        <div className="container card">
        <label className="control-label">{message}</label>
      </div>
    );
  }