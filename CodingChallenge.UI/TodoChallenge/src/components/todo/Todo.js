import React, {useState} from 'react';
import {TodoModel} from "../../TodoModel";
import PropTypes from "prop-types";
import { FiCheckCircle, FiCircle, FiEdit2, FiSave, FiX } from 'react-icons/fi';
import './todo.scss';

const Todo = (props) => {
    const [editing, setStateEditing] =  useState(false);
    const [editingText, setStateEditText] = useState(props.todo.text);


    const toggleComplete = () => {
        props.onCompleteChange({...props.todo, isComplete: !props.todo.isComplete});
    }

    const toggleEditText = () => {
        setStateEditing(!editing);
    }

    const saveText = () => {
        if (!editing) return;
        props.onTextChange(editingText, props.todo.id, props.todo);
        toggleEditText();
    };

    const cancelEdit = () => {
        setStateEditText(props.todo.text);
        toggleEditText();
    };

    const onChangeEditText = (event) => {
        setStateEditText(event.target.value);
    }

    const displayText = () => {
        if (editing)
        {
            return <input onChange={onChangeEditText} value={editingText} className="todo-edit-input"></input>
        }
        else
        {
            return <span className="todo-text">{props.todo.text}</span>;
        }
    }
    const getClassName = () => {
        const {isComplete} = props.todo;
        return `todo-item ${isComplete ? 'complete' : 'incomplete'}`;
    }

    return (
        <div className={getClassName()}>
            <div className="todo-content">
                {displayText()}
            </div>
            <div className="todo-icons">
                <button onClick={toggleComplete} className="icon-button" title={props.todo.isComplete ? "Mark incomplete" : "Mark complete"}>
                    {props.todo.isComplete ? <FiCheckCircle /> : <FiCircle />}
                </button>
                {editing
                    ? <>
                        <button onClick={saveText} className="icon-button" title="Save">
                            <FiSave />
                        </button>
                        <button onClick={cancelEdit} className="icon-button" title="Cancel">
                            <FiX />
                        </button>
                    </>
                    : <button onClick={toggleEditText} className="icon-button" title="Edit">
                        <FiEdit2 />
                    </button>
                }
            </div>
        </div>
    )
}

Todo.propTypes = {
    todo: PropTypes.shape(TodoModel),
    onTextChange: PropTypes.func,
    onCompleteChange: PropTypes.func
};

export default Todo;