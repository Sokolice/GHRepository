interface Props {
    x: number,
    y: number
}
export default function Cell({x, y }:Props) {

    function handleClick(x: number, y: number) {
        alert(x + ' ' + y + ' klik');
    }

    return (
        <div className='grid-item' onClick={() => handleClick(x,y)} key={x + '_' + y}>
        </div>
    )
}