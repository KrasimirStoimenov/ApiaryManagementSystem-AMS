import { Link } from 'react-router-dom';

import { formatIsoStringToDisplayDate } from '../../../utils/dateUtils';

export default function HarvestListItem({
    harvest
}) {
    return (
        <tr>
            <td>{formatIsoStringToDisplayDate(harvest.date)}</td>
            <td>{Number(harvest.amount).toFixed(2)}</td>
            <td>{harvest.product}</td>
            <td><Link to={`/hives/${harvest.hiveId}/details`}>№{harvest.hive.number} - {harvest.hive.color}</Link></td>
        </tr>
    );
};