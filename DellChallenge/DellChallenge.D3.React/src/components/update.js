import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Validation from "../validation";

function validate(name) {
  const errors = [];

  if (name.length === 0) {
    errors.push("Name can't be empty");
  }

  return errors;
}
class UpdateProduct extends Component {
  constructor() {
    super();
    this.state = {
	  Id: "",
      Name: "",
      Category: "",
	  errors: [],
      Success: false,
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit = event => {
    event.preventDefault();
    let updateData = {
	  Id: this.state.Id,
      Name: this.state.Name,
      Category: this.state.Category
    };
    const errors = validate(this.state.Name);
    if (errors.length > 0) {
      this.setState({ errors });
      return;
    }

    fetch("http://localhost:5000/api/products/"+ this.state.Id, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors",
      body: JSON.stringify(updateData)
    })
    .then(res => res.json())
    .then(this.props.history.push('/products'))
    .catch(err => console.log(err));
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  };

  render() {
	  const { errors } = this.state;
    return (
      <form onSubmit={this.handleSubmit}>
        <h4>Update Products</h4>
		<div className="form-group">
		{errors.map(error => (
          <p key={error}>Error: {error}</p>
        ))}
          <label className="control-label" htmlFor="Id">
            Id
          </label>
          <input
            className="form-control"
            type="text"
            id="Id"
            name="Id"
            onChange={this.handleInputChange}
            value={this.state.Id}
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Id"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <label className="control-label" htmlFor="Name">
            Name
          </label>
          <input
            className="form-control"
            type="text"
            id="Name"
            name="Name"
            onChange={this.handleInputChange}
            value={this.state.Name}
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Name"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <label className="control-label" htmlFor="Category">
            Category
          </label>
          <input
            className="form-control"
            type="text"
            id="Category"
            name="Category"
            onChange={this.handleInputChange}
            value={this.state.Category}
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Category"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <button className="btn btn-primary">Submit</button>
        </div>
        <Validation />
      </form>
    );
  }
}

export default UpdateProduct;
