import { Link } from 'react-router-dom';
import { formatIsoStringToDisplayDate } from '../../../utils/dateUtils';

export default function InspectionListItem({
    inspection
}) {
    return (
        <tr>
            <td>{formatIsoStringToDisplayDate(inspection.date)}</td>
            <td>{inspection.weatherConditions}</td>
            <td>{inspection.observations}</td>
            <td>{inspection.actionsTaken}</td>
            <td><Link to={`/hives/${inspection.hiveId}/details`}>№{inspection.hive.number} - {inspection.hive.color}</Link></td>
        </tr>
    );
};