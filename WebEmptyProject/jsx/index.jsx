class Application extends React.Component {
    render() {
        return (
            <div id="application_inner" className="application_inner"></div>
        )
    }
};

ReactDOM.render(<Application/>, document.getElementById('application_box'));
