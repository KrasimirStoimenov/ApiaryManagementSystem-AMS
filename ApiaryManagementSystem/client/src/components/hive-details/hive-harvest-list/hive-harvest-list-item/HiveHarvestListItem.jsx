import { Link } from "react-router-dom";

import { Button } from "react-bootstrap";

import { formatIsoStringToDisplayDate } from "../../../../utils/dateUtils";

export default function HiveHarvestListItem({
    hiveHarvest,
    deleteClickHandler
}) {
    return (
        <tr>
            <td>{formatIsoStringToDisplayDate(hiveHarvest.date)}</td>
            <td>{Number(hiveHarvest.amount).toFixed(2)}</td>
            <td>{hiveHarvest.product}</td>
            <td className='list-items-helper-buttons'>
                <Button as={Link} to={`/harvests/${hiveHarvest._id}/edit`} variant='warning'><i className="bi bi-pencil-square"></i> Edit</Button>
                <Button variant='danger' onClick={() => deleteClickHandler(hiveHarvest._id)}><i className="bi bi-trash-fill"></i> Delete</Button>
            </td>
        </tr>
    );
}