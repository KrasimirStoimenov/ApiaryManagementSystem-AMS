import { Link } from 'react-router-dom';

export default function BeeQueenListItem({
    beeQueen
}) {
    return (
        <tr>
            <td>{beeQueen.year}</td>
            <td>{beeQueen.colorMark}</td>
            <td>{beeQueen.isAlive ? 'Yes' : 'No'}</td>
            <td><Link to={`/hives/${beeQueen.hiveId}/details`}>№{beeQueen.hive.number} - {beeQueen.hive.color}</Link></td>
        </tr>
    );
};