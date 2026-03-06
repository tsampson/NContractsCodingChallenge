import React from 'react';
import { PieChart, Pie, Cell, Legend, Tooltip, ResponsiveContainer } from 'recharts';
import './TodoChart.scss';

const TodoChart = ({ todos }) => {
    const completeCount = (todos || []).filter(todo => todo.isComplete).length;
    const incompleteCount = (todos || []).length - completeCount;

    const data = [
        { name: 'Done', value: completeCount },
        { name: 'Not Done', value: incompleteCount }
    ];

    const COLORS = ['#1e88e5', '#26a69a'];

    return (
        <div className="todo-chart">
            <ResponsiveContainer width="100%" height={300}>
                <PieChart>
                    <Pie
                        data={data}
                        cx="50%"
                        cy="50%"
                        innerRadius={80}
                        outerRadius={120}
                        paddingAngle={5}
                        dataKey="value"
                    >
                        {data.map((entry, index) => (
                            <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                        ))}
                    </Pie>
                    <Tooltip />
                    <Legend />
                </PieChart>
            </ResponsiveContainer>
        </div>
    );
};

export default TodoChart;
