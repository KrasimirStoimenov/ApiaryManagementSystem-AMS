import { Link } from "react-router-dom";

import { Button } from "react-bootstrap";
import { formatIsoStringToDisplayDate } from "../../../../utils/dateUtils";

export default function HiveInspectionListItem({
    hiveInspection,
    deleteClickHandler
}) {
    return (
        <tr>
            <td>{formatIsoStringToDisplayDate(hiveInspection.date)}</td>
            <td>{hiveInspection.weatherConditions}</td>
            <td>{hiveInspection.observations}</td>
            <td>{hiveInspection.actionsTaken}</td>
            <td className='list-items-helper-buttons'>
                <Button as={Link} to={`/inspections/${hiveInspection._id}/edit`} variant='warning'><i className="bi bi-pencil-square"></i> Edit</Button>
                <Button variant='danger' onClick={() => deleteClickHandler(hiveInspection._id)}><i className="bi bi-trash-fill"></i> Delete</Button>
            </td>
        </tr>
    );
}