import React, {Component} from 'react';
import TodoList from "./components/todo/TodoList";
import "./App.scss";
import './button.scss';
import TodoService from './TodoService';
import TodoChart from './components/chart/TodoChart';
import {connect} from 'react-redux';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      newTodo: ''
    };
  }

  textInputChange = (e) =>  {
    this.setState({...this.state, newTodo: e.target.value});
  }

  addNewTodo = async () => {
    if (this.state.newTodo.trim()) {
      await TodoService.addTodo(this.state.newTodo);
      this.setState({newTodo: ''});
    }
  }

  render() {
    return (
      <div className="App">
        <input type="text" value={this.state.newTodo} onChange={this.textInputChange}></input>
        <button className={"btn--default"} onClick={this.addNewTodo}>Add</button>
        <TodoChart todos={this.props.todos} />
        <TodoList />
      </div>
    );
  }
}

const mapStateToProps = (state) => ({
  todos: state.todos ?? []
});

export default connect(mapStateToProps)(App);