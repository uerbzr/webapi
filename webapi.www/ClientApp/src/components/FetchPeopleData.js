import React, { Component } from 'react';

export class FetchPeopleData extends Component {
  static displayName = FetchPeopleData.name;

  constructor(props) {
    super(props);
    this.state = { people: [], loading: true };
  }

  componentDidMount() {
      this.populatePeopleData();
  }

    static renderPeopleTable(people) {
        //console.log(people);
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
    
            <th>Name</th>
            <th>Email</th>            
          </tr>
        </thead>

            <tbody>
                {
                    people.map(p =>
                        <tr key={p.id}>
                            <td>{ p.name}</td>
                            <td>{ p.email}</td>                        
                            <td>
                                <a  className="btn btn-warning btn-sm">Edit</a>&nbsp;
                                <a  className="btn btn-danger btn-sm">Delete</a>
                            </td>
                        </tr>                   
                    )}
               
                </tbody>

      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchPeopleData.renderPeopleTable(this.state.people);

    return (
      <div>
        <h1 id="tableLabel">People Data</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

    async populatePeopleData() {    
      const response = await fetch('https://localhost:7084/people');
        const data = await response.json();
        console.log(data);
    this.setState({ people: data, loading: false });
  }
}
