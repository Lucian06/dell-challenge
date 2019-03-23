import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Validation from "../validation";

class DeleteProduct extends Component {
  constructor() {
    super();
    this.state = {
      Id: "",
      Success: false,
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit = event => {
    event.preventDefault();
    let deleteData = {
      Id: this.state.Id,
    };

    fetch("http://localhost:5000/api/products/" + this.state.Id, {
      method: "DELETE",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors",
      body: JSON.stringify(deleteData)
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
    return (
      <form onSubmit={this.handleSubmit}>
        <h4>Delete Product</h4>
        <div className="form-group">
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
          <button className="btn btn-primary">Submit</button>
        </div>
        <Validation />
      </form>
    );
  }
}

export default DeleteProduct;
