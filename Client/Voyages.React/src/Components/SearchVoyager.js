import { useState } from 'react';
import VoyageInfo from "./VoyageInfo"
import {Message} from "./Elements"

export default function SearchVoyager() {

    const [inputs, setInputs] = useState({name:'',lastname:''});
    const [search, setSearch] = useState({search: false, mandatory: false});

    const handleChange = (event) => {
      const name = event.target.name;
      const value = event.target.value;
      setInputs(values => ({...values, [name]: value}));      
      setSearch({search: false, mandatory: false});
    }
  
    const handleSubmit = (event) => {
      event.preventDefault();      
      
      if(inputs.name === '' || inputs.lastname === '') {
        setSearch({mandatory: true});  
      }
      else {
        setSearch({search: true});      
      }
    }
  
    return (

      <>
        <form onSubmit={handleSubmit}>
          <div className="search-form1 search-view-web1 row">
              <div id="search-field-div1" className="col-lg-5 col-md-5 col-sm-12 col-xs-12 col-margin">
                      <input type="text" className="form-control text-input rounded" id="name" name="name" value={inputs.name || ""} placeholder="Prénom..." onChange={handleChange} />
              </div>
              <div id="search-field-div2" className="col-lg-5 col-md-5 col-sm-12 col-xs-12 col-margin">
                  <input type="text" id="lastname" name="lastname" className="form-control text-input rounded" value={inputs.lastname || ""} placeholder="Nom..." onChange={handleChange} />
              </div>
              <div id="search-button-div1" className="col-lg-2 col-md-2 col-sm-12 col-xs-12 tourz-search-form col-margin">
                  <input type="submit" id="btn-search" value="Rechercher" style={{ borderRadius: '5px', height: '32px', lineHeight: '32px'}} className="btn-tui-search-link-red rounded" />
              </div>
          </div>
          <div className="">
            <span className="text-example">Examples: Jean Monet, Pierre Moulin</span>
          </div>
      </form>

      {(search.search === true || search.mandatory === true) &&
      
        <div className="rows inn-page-bg com-colo">
          <div className="container row inn-page-con-bg tb-space col-md-12 " style={{padding:'0px', margin: '40px', marginLeft:'10%', marginRight:'10%', width:'80%'}} >
                  
            <div id="productresults" className="col-md-12 ">
                      
              <div className="rows pad-bot-redu tb-space bloques">
                
                {search.search === true &&
                  <div><VoyageInfo name={inputs.name} lastname={inputs.lastname}/></div>
                }

                { search.mandatory === true &&
                  <Message message="Le prénom et nom du client sont obligatoires."/>
                }

              </div>
            </div>
          
          </div> 

        </div>
      }

        {/* <form onSubmit={handleSubmit}>
          <label>Prénom:
          <input 
            type="text" 
            id="name" 
            name="name" 
            value={inputs.name || ""} 
            onChange={handleChange}
          />
          </label>
          <label>Nom:
            <input 
              type="text" 
              id="lastname" 
              name="lastname" 
              value={inputs.lastname || ""} 
              onChange={handleChange}
            />
            </label>
            <button type="submit">Chercher</button>
            
            <div id="info"></div>

            {search.search === true &&
            <div><VoyageInfo name={inputs.name} lastname={inputs.lastname}/></div>
            }
        </form> */}
      </>
    )

}