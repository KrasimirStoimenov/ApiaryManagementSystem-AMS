import { Link } from 'react-router-dom';

import { Button } from "react-bootstrap";

export default function HiveBeeQueenListItem({
    beeQueen,
    deleteClickHandler
}) {
    return (
        <tr>
            <td>{beeQueen.year}</td>
            <td>{beeQueen.colorMark}</td>
            <td>{beeQueen.isAlive ? 'Yes' : 'No'}</td>
            <td className='list-items-helper-buttons'>
                <Button as={Link} to={`/beeQueens/${beeQueen._id}/edit`} variant='warning'><i className="bi bi-pencil-square"></i> Edit</Button>
                <Button variant='danger' onClick={() => deleteClickHandler(beeQueen._id)}><i className="bi bi-trash-fill"></i> Delete</Button>
            </td>
        </tr>
    );
};